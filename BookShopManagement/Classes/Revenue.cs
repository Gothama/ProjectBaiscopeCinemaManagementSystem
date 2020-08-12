using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookShopManagement.Classes;
using MySql.Data.MySqlClient;

namespace BookShopManagement.Classes
{
    class Revenue
    {
        public DBConnect dbconnect = new DBConnect();

        public Revenue()
        {
            
        }
        public DataGridView getAllTickets()
        {
            DataGridView datagridview = new DataGridView();
            string query = "select ";
            using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, dbconnect.connection))
            {
                DataSet dset = new DataSet();
                adpt.Fill(dset);
                datagridview.DataSource = dset.Tables[0];
            }
            return datagridview;
        }
      
    }
}
