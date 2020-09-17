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
using MySql.Data.MySqlClient;

namespace BookShopManagement.UserControls
{
    public partial class UC_TotalRevenue : UserControl
    {
        public UC_TotalRevenue()
        {
            InitializeComponent();
            getSales();
        }
        public void getSales()
        {
            DBConnect dBConnect = new DBConnect();

          
           MySqlDataAdapter sqldata = new MySqlDataAdapter("getSales", dBConnect.connection);
           sqldata.SelectCommand.CommandType = CommandType.StoredProcedure;
           DataTable dttable = new DataTable();
           sqldata.Fill(dttable);
           dataGridView1.DataSource = dttable;
           dataGridView1.Columns[0].HeaderText = "Ticket Number";
           dataGridView1.Columns[1].HeaderText = "Seat Number";
           dataGridView1.Columns[2].HeaderText = "Movie Name";
           dataGridView1.Columns[3].HeaderText = "Customer NIC";
           dataGridView1.Columns[4].HeaderText = "Date";
           dataGridView1.Columns[5].HeaderText = "Time Slot";



        }
    }
}
