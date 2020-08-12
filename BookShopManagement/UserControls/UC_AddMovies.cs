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
    public partial class UC_AddMovies : UserControl
    {
        private Movies movies;
        private string m = "";
        public UC_AddMovies()
        {
            InitializeComponent();
            movies = new Movies();
            getMovieDetails();

        }

        private void btnAddNewBooks_Click(object sender, EventArgs e)
        {
            using (Form_AddNewMovie abn = new Form_AddNewMovie())
            {
                abn.ShowDialog();
            }
            getMovieDetails();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            movies.deleteMovie(m);
            getMovieDetails();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            m = row.Cells["movieNameDataGridViewTextBoxColumn"].Value.ToString();
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
            dataGridView1.Columns[0].HeaderText = "Movie ID";
            dataGridView1.Columns[1].HeaderText = "Movie Name";
            dataGridView1.Columns[2].HeaderText = "Movie Released Date";
            dataGridView1.Columns[3].HeaderText = "Movie Type";
            dataGridView1.Columns[4].HeaderText = "Trailer Link";
         

        }

    }
}
