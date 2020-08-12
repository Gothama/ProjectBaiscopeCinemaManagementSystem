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
    public partial class UC_SeeMoviesDetails : UserControl
    {
        public UC_SeeMoviesDetails()
        {
            InitializeComponent();
        }

        private void UC_SeeMoviesDetails_Load(object sender, EventArgs e)
        {
          
            getMovieDetails();

        }
        private void getMovieDetails()
        {

            DBConnect dBConnect = new DBConnect();


            MySqlDataAdapter sqldata = new MySqlDataAdapter("getMovies", dBConnect.connection);
            sqldata.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dttable = new DataTable();
            sqldata.Fill(dttable);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = dttable;


            dataGridView1.DataSource = bSource;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            QRCodeGenerate gr = new QRCodeGenerate();
            pictureBox1.Image = gr.trailerLinkQRcode(row.Cells["trailerLinkDataGridViewTextBoxColumn"].Value.ToString());
            
        }

        
    }
}
