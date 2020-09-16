using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookShopManagement.Forms;
using BookShopManagement.Classes;
using System.Text.RegularExpressions;

namespace BookShopManagement.UserControls
{
    public partial class UC_SignUp : UserControl
    {
        
        public UC_SignUp()
        {
            InitializeComponent();
            
        }
        public UC_SignUp(string firstName, string secondName, string password, string username, string accType, string nIC, string email)
        {
            InitializeComponent();

            txtFirstName.Text = firstName;
            txtSecondName.Text = secondName;
            txtUserName.Text = username;
            txtNic.Text = nIC;
            txtPassword.Text = password;
            txtEmail.Text = email;
            
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (!(String.IsNullOrEmpty(txtFirstName.Text.Trim()) && String.IsNullOrEmpty(txtSecondName.Text.Trim()) && String.IsNullOrEmpty(txtPassword.Text.Trim()) && String.IsNullOrEmpty(txtUserName.Text.Trim()) && String.IsNullOrEmpty(txtNic.Text.Trim()) && String.IsNullOrEmpty(txtEmail.Text.Trim())))
            {
                string FirstName = txtFirstName.Text.ToString();
                string SecondName = txtSecondName.Text.ToString();
                string Password = txtPassword.Text.ToString();
                string Username = txtUserName.Text.ToString();
                string AccType = "C";
                string NIC = txtNic.Text.ToString();
                string Email = txtEmail.Text.ToString();

                Account account = new Account(FirstName, SecondName, Password, Username, AccType, NIC, Email);
                account.createAccount();
            }
            else
            {
                MessageBox.Show("Pls Fill All the Data" );
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
           //((Form)this.TopLevelControl).Dispose();
        }

        private void UC_SignUp_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void txtSecondName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))

            {

                e.Handled = true;

            }
        }

        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))

            {

                e.Handled = true;

            }
        }

        private void txtNic_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))

            {

                e.Handled = true;

            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            Regex mRegxExpression;
            if (txtEmail.Text.Trim() != string.Empty)
            {
                mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");

                if (!mRegxExpression.IsMatch(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("E-mail address format is not correct.", "MojoCRM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                }
            }
        }
    }
}
