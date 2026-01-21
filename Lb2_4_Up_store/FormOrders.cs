using Lb2_4_Up_store.Models;
using Microsoft.EntityFrameworkCore;

namespace Lb2_4_Up_store
{
    public partial class FormOrders : Form
    {
        public User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }

        public FormOrders(User user, bool guest)
        {
            InitializeComponent();

            var colInfo = new DataGridViewTextBoxColumn();
            colInfo.Name = "colInfo";
            colInfo.FillWeight = 70;
            colInfo.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            var colDate = new DataGridViewTextBoxColumn();
            colDate.Name = "colDate";
            colDate.FillWeight = 10;
            colDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvOrders.Columns.AddRange(
            [
                colInfo, colDate
            ]);

            CurrentUser = user;
            IsGuest = guest;

            lblUserNameOrder.Text = IsGuest ? "Гость" : CurrentUser.FullName;
        }

        private void LoadProducts()
        {
            try
            {
                using (var db = new StoreUpUporovContext())
                {
                    var orders = db.Orders
                        .Include(i => i.Status)
                        .Include(i => i.DeliveryPoint)
                        .Include(i => i.ProductsOrders).ThenInclude(i=>i.Product)
                        .ToList();

                    dgvOrders.SuspendLayout();
                    dgvOrders.Rows.Clear();

                    foreach (var order in orders)
                    {
                        int rowIndex = dgvOrders.Rows.Add();
                        var row = dgvOrders.Rows[rowIndex];


                        row.Cells["colInfo"].Value = FormatOrdersInfo(order);

                        //row.Cells["colDate"].Value = FormatOrdersDate(order);

                        //ApplyRowStyles(row, order);
                    }

                    dgvOrders.ResumeLayout();
                    dgvOrders.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private string FormatOrdersInfo(Order order)
        {            
            var arts = order.ProductsOrders.FirstOrDefault().Product.Art;

            return $"Артикул: {order.ProductsOrders.}" + Environment.NewLine +
                $"Статус заказа: {order.}" + Environment.NewLine +
                $"Адрес пункта выдачи: {order.DeliveryPoint.DeliveryAddress}" + Environment.NewLine +
                $"Дата заказа: {order.OrderDate}" + Environment.NewLine;
        }

        private void BtnLogutOrder_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
