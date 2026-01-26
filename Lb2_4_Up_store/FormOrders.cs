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
            colDate.FillWeight = 20;
            colDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvOrders.Columns.AddRange(
            [
                colInfo, colDate
            ]);

            CurrentUser = user;
            IsGuest = guest;

            lblUserNameOrder.Text = IsGuest ? "Гость" : CurrentUser.FullName;

            LoadOrder();
        }

        private void LoadOrder()
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

                        row.Cells["colDate"].Value = $"{order.DeliveryDate}";
                        row.Cells["colDate"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
            string arts = "";
            foreach (var productOrder in order.ProductsOrders.ToList())
            {
                arts=arts+" "+ productOrder.Product.Art;
            }

            return $"Артикул: {arts}" + Environment.NewLine +
                $"Статус заказа: {order.Status.StatusName}" + Environment.NewLine +
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
