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
using MySql.Data.MySqlClient;

namespace BookShopManagement.UserControls
{
    public partial class UC_ManageExpense : UserControl
    {
        public UC_ManageExpense()
        {
            InitializeComponent();
            getExpenses();
        }

        private void btnAddNewExpense_Click(object sender, EventArgs e)
        {
            using (Form_AddExpense ae = new Form_AddExpense())
            {
                ae.ShowDialog();
            }
            getExpenses();
        }
        private void getExpenses()
        {
            DBConnect dBConnect = new DBConnect();


            MySqlDataAdapter sqldata = new MySqlDataAdapter("getExpenses", dBConnect.connection);
            sqldata.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dttable = new DataTable();
            sqldata.Fill(dttable);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = dttable;


            dataGridView1.DataSource = bSource;
            dataGridView1.Columns[0].HeaderText = "Expense ID";
            dataGridView1.Columns[1].HeaderText = "Expense Title";
            dataGridView1.Columns[2].HeaderText = "Amount";
            dataGridView1.Columns[3].HeaderText = "Description";
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
