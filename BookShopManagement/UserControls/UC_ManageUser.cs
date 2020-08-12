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
using System.Text.RegularExpressions;

namespace BookShopManagement.UserControls
{
    public partial class UC_ManageUser : UserControl
    {
        public UC_ManageUser()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text.ToString() != "" && txtSecondName.Text.ToString() != " " && txtEmail.Text.ToString() != "" && txtPassword.Text.ToString() != "" && txtUsername.Text.ToString() != "" && txtNIC.Text.ToString() != "" && comboRole.Text.ToString() != "")
            {
                string Fname = txtFirstName.Text;
                string Sname = txtSecondName.Text;
                string Email = txtEmail.Text;
                string password = txtPassword.Text;
                string username = txtUsername.Text;
                string NIC = txtNIC.Text;
                string accType;
                if (comboRole.Text.ToString() == "Administrator")
                {
                    accType = "S";
                }
                else
                {
                    accType = "C";
                }


                try
                {
                    Account account = new Account(Fname, Sname, password, username, accType, NIC, Email);
                    account.createAccount();
                    MessageBox.Show("Successfull");
                }
                catch (Exception j)
                {
                    MessageBox.Show(j.Message);
                }
            }
            else
            {
                MessageBox.Show("Pls Fill all the fields");
            }
            
        }

        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))

            {

                e.Handled = true;

            }
        }

        private void txtSecondName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))

            {

                e.Handled = true;

            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))

            {

                e.Handled = true;

            }
        }

        private void txtNIC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)&& !char.IsDigit(e.KeyChar))

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
