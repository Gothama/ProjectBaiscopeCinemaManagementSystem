using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookShopManagement.Classes;

namespace BookShopManagement.UserControls
{
    public partial class UC_Home : UserControl
    {
        string password, username;
        
        public UC_Home(string password, string username)
        {
            InitializeComponent();
            this.username = username;
            this.password = password;
        }
        public UC_Home()
        {
            InitializeComponent();
        }
        private void UC_Home_Load(object sender, EventArgs e)
        {
            Account account = new Account(username , password);
            account.getDetails();
            txtFirstName.Text = account.FirstName;
            txtUserName.Text = account.Username;
            txtSecondName.Text = account.SecondName;
            txtPassword.Text = account.Password;
            txtNic.Text = account.NIC;
            txtEmail.Text = account.Email;
        }
    }
}
