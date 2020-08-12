using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookShopManagement.Classes;
using MySql.Data.MySqlClient;

namespace BookShopManagement.Forms
{
    public partial class Form_AddExpense : Form
    {
        public Form_AddExpense()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(String.IsNullOrEmpty(txtExpenseTitle.Text) && String.IsNullOrEmpty(txtDescription.Text) && String.IsNullOrEmpty(txtAmount.Text)))
            {
                try
                {
                    string expenseTitle = txtExpenseTitle.Text;
                    Decimal amount = Convert.ToDecimal(txtAmount.Text);
                    string description = txtDescription.Text;

                    DBConnect dBConnect = new DBConnect();
                    MySqlCommand mysqlcmd = new MySqlCommand("addExpenses", dBConnect.connection);
                    mysqlcmd.CommandType = CommandType.StoredProcedure;

                    mysqlcmd.Parameters.AddWithValue("_expenseTitle", expenseTitle);
                    mysqlcmd.Parameters.AddWithValue("_amount", amount);
                    mysqlcmd.Parameters.AddWithValue("_description", description);

                    mysqlcmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully added the expense");
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
            else
            {
                MessageBox.Show("Pls Fill all the fields");
            }
        }

        private void txtExpenseTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))

            {

                e.Handled = true;

            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))

            {

                e.Handled = true;

            }
        }

        
    }
}
