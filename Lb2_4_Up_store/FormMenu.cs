using Lb2_4_Up_store.Models;

namespace Lb2_4_Up_store
{
    public partial class FormMenu : Form
    {
        public User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }

        public FormMenu(User user, bool guest)
        {
            InitializeComponent();

            CurrentUser = user;
            IsGuest = guest;

            lblUserNameMenu.Text = IsGuest ? "Гость" : CurrentUser.FullName;
        }

        private void BtnLogutMenu_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnOrder_Click(object sender, EventArgs e)
        {
            FormOrders formOrders = new FormOrders(CurrentUser, IsGuest);
            this.Hide();
            formOrders.ShowDialog();
            this.Show();
        }

        private void BtnProducts_Click(object sender, EventArgs e)
        {
            FormProducts formProducts = new FormProducts(CurrentUser, IsGuest);
            this.Hide(); 
            formProducts.ShowDialog(); 
            this.Show();
        }
    }
}
