using Lb2_4_Up_store.Models;
using Lb2_4_Up_store.Properties;
using Microsoft.EntityFrameworkCore;

namespace Lb2_4_Up_store
{
    public partial class FormMenu : Form
    {
        public User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }

        public FormMenu()
        {
            InitializeComponent();

            //CurrentUser = user;
            //IsGuest = guest;

            lblUserNameMenu.Text = IsGuest ? "Гость" : CurrentUser.FullName;
        }

        private void BtnLogutMenu_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
