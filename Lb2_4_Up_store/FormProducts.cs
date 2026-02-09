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
            colInfo.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

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
                    var products = db.Products
                        .Include(i => i.Category)
                        .Include(i => i.Manufacturer)
                        .Include(i => i.Supplier)
                        .Include(i => i.Measure)
                        .Include(i =>i.ProductType)
                        .ToList();

                    dgvProducts.SuspendLayout();
                    dgvProducts.Rows.Clear();

                    foreach (var product in products)
                    {
                        int rowIndex = dgvProducts.Rows.Add();
                        var row = dgvProducts.Rows[rowIndex];

                        row.Cells["colPhoto"].Value = LoadProductImage(product.PhotoUrl);

                        row.Cells["colInfo"].Value = FormatProductInfo(product);

                        row.Cells["colDiscount"].Value = $"{product.Discount}%";
                        row.Cells["colDiscount"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        ApplyRowStyles(row, product);
                    }

                    dgvProducts.ResumeLayout();
                    dgvProducts.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyRowStyles(DataGridViewRow row, Product product)
        {
            if (product.Discount > 15)
            {
                row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#2E8B57");
                row.DefaultCellStyle.ForeColor = Color.White;
            }

            if (product.CointInStock <= 0)
            {
                row.DefaultCellStyle.BackColor = Color.LightBlue;
                if (product.Discount <= 15)
                {
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }

            if (product.Discount > 0)
            {
                row.Cells["colDiscount"].Style.ForeColor = Color.Red;
                row.Cells["colDiscount"].Style.Font = new Font(
                    "Times New Roman",
                    12,
                    FontStyle.Bold);
            }
        }

        private string FormatProductInfo(Product product)
        {
            string priceText;

            if (product.Discount > 0)
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
                $"{priceText}" + Environment.NewLine +
                $"Еденица измерения: {product.Measure.MeasureName}" + Environment.NewLine +
                $"Количество на складе: {product.CointInStock}" + Environment.NewLine;
        }

        private Image LoadProductImage(string photoUrl)
        {
            try
            {
                // Проверяем, содержит ли photoUrl имя файла из Resources 
                if (!String.IsNullOrWhiteSpace(photoUrl))
                {
                    string fileName = System.IO.Path.GetFileNameWithoutExtension(photoUrl);

                    var resourceProperty = Resources.ResourceManager.GetObject(fileName) as Image;
                    if (resourceProperty != null)
                    {
                        return resourceProperty;
                    }
                }

                if (!String.IsNullOrWhiteSpace(photoUrl))
                {
                    if (int.TryParse(photoUrl.Replace("img", ""), out int imgNumber))
                    {
                        return imgNumber switch
                        {
                            1 => Resources.img1,
                            2 => Resources.img2,
                            3 => Resources.img3,
                            4 => Resources.img4,
                            5 => Resources.img5,
                            6 => Resources.img6,
                            7 => Resources.img7,
                            8 => Resources.img8,
                            9 => Resources.img9,
                            10 => Resources.img10,
                            _ => Resources.picture 
                        };
                    }
                }
                return Resources.picture;
            }
            catch (Exception ex)
            {
                return Resources.picture;
            }
        }

        private void BtnLogut_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }
    }
}
