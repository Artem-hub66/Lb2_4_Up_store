using Lb2_4_Up_store.Models;
using Lb2_4_Up_store.Properties;
using Microsoft.EntityFrameworkCore;

namespace Lb2_4_Up_store
{
    public partial class FormProducts : Form
    {
        public User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }

        public FormProducts(User user, bool guest)
        {
            InitializeComponent();

            var colPhoto = new DataGridViewImageColumn();
            colPhoto.Name = "colPhoto";
            colPhoto.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colPhoto.Width = 200;
            colPhoto.FillWeight = 30;

            var colInfo = new DataGridViewTextBoxColumn();
            colInfo.Name = "colInfo";
            colInfo.FillWeight = 60;
            colInfo.DefaultCellStyle.WrapMode=DataGridViewTriState.True;

            var colDiscount = new DataGridViewTextBoxColumn();
            colDiscount.Name = "colDiscount";
            colDiscount.FillWeight = 10;
            colDiscount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvProducts.Columns.AddRange(
            [
                colPhoto, colInfo, colDiscount
            ]);

            CurrentUser = user;
            IsGuest = guest;

            lblUserName.Text = IsGuest ? "Гость" : CurrentUser.FullName;

            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                using (var db = new StoreUpUporovContext())
                {
                    var products = db.Products.Include(i => i.Category)
                        .Include(i => i.Manufacturer)
                        .Include(i => i.Supplier)
                        .Include(i => i.Measure)
                        .ToList();

                    dgvProducts.SuspendLayout();
                    dgvProducts.Rows.Clear();

                    foreach (var product in products)
                    {
                        int rowIndex = dgvProducts.Rows.Add();
                        var row = dgvProducts.Rows[rowIndex];

                        row.Cells["colPhoto"].Value = LoadProductImage(product.PhotoUrl);

                        row.Cells["colInfo"].Value = FormatProductInfo(product);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
            
        }

        private string FormatProductInfo(Product product)
        {
            string priceText;

            if(product.Discount > 0)
            {
                decimal finalPrice = product.Price * (100 - product.Discount) / 100;
                priceText = $"Цена: {product.Price:C} -> {finalPrice:C}";
            }
            else
            {
                priceText = $"Цена: {product.Price:C}";
            }
            return $"{product.Category.CategoryName} | {product.ProductType}" + Environment.NewLine +
                $"Описание товара: {product.Description}" + Environment.NewLine +
                $"Производитель: {product.Manufacturer.ManufacturerName}" + Environment.NewLine +
                $"Поставщик: {product.Supplier.SupplierName}" + Environment.NewLine +
                $"Цена: {priceText}" + Environment.NewLine +
                $"Еденица измерения: {product.Measure.MeasureName}" + Environment.NewLine +
                $"Количество на складе: {product.CointInStock}" + Environment.NewLine; 
        }

        private Image LoadProductImage(string photoUrl)
        {
            if(!String.IsNullOrEmpty(photoUrl) && System.IO.File.Exists(photoUrl))
            {
                return Image.FromFile(photoUrl);
            }

            return Resources.picture;
        }
    }
}
