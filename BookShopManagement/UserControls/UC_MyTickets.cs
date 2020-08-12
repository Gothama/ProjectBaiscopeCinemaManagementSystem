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
using System.Data.SqlClient;

namespace BookShopManagement.UserControls
{
    public partial class UC_MyTickets : UserControl
    {
        public string NIC;
        public UC_MyTickets(string NIC)
        {
            InitializeComponent();
            this.NIC = NIC;
        }

        private void UC_MyTickets_Load(object sender, EventArgs e)
        {
            DBConnect dBConnect = new DBConnect();

            MySqlDataAdapter sqldata = new MySqlDataAdapter("getMyTickets", dBConnect.connection);
            sqldata.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqldata.SelectCommand.Parameters.AddWithValue("_cusNIC", NIC );
            DataTable dttable = new DataTable();
            sqldata.Fill(dttable);
            dataGridView1.DataSource = dttable;
            dataGridView1.Columns[0].HeaderText = "Ticket Number";
            dataGridView1.Columns[1].HeaderText = "Seat Number";
            dataGridView1.Columns[2].HeaderText = "Movie Name";
            dataGridView1.Columns[3].HeaderText = "Date";
            dataGridView1.Columns[4].HeaderText = "Time Slot";


           
            
        }
    }
}
