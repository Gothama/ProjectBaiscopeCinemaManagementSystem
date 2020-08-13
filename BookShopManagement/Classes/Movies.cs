using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookShopManagement.Classes;
using MySql.Data.MySqlClient;
using BookShopManagement.Forms;

namespace BookShopManagement.Classes
{
    class Movies: DBConnect
    {
        private string movieID, movieName, movieReleasedDate, movieType, movieTrailerLink;
        DBConnect dBConnect = new DBConnect();

        public void addMovieToDataBase(string movieName, string movieReleasedDate, string movieType, string movieTrailerLink)
        {
            try
            {
                
                dBConnect = new DBConnect();
                MySqlCommand mysqlcmd = new MySqlCommand("AddMovies", dBConnect.connection);
                mysqlcmd.CommandType = CommandType.StoredProcedure;

                mysqlcmd.Parameters.AddWithValue("_movieName", movieName);
                mysqlcmd.Parameters.AddWithValue("_movieReleasedDate", movieReleasedDate);

                mysqlcmd.Parameters.AddWithValue("_movieType", movieType);
                mysqlcmd.Parameters.AddWithValue("_trailerLink", movieTrailerLink);
                
                mysqlcmd.ExecuteNonQuery();
                MessageBox.Show("Successfully added a movie");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public DataGridView getAllMovies()
        {
            
            
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string sqlSelectAll = "SELECT * FROM cinemamanagementsystem.moviesdetails";
            MyDA.SelectCommand = new MySqlCommand(sqlSelectAll, dBConnect.connection);

            DataTable table = new DataTable();
            MyDA.Fill(table);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;

            DataGridView datagridview = new DataGridView();
            datagridview.DataSource = bSource;
            return datagridview;
        }
        public DataGridView getAllRevenue()
        {
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string sqlSelectAll = "SELECT COUNT(cusNIC) , COUNT(cusNIC)*price AS TotalRevenue, movieName FROM cinemamanagementsystem.tickets GROUP BY movieName";
            MyDA.SelectCommand = new MySqlCommand(sqlSelectAll, dBConnect.connection);

            DataTable table = new DataTable();
            MyDA.Fill(table);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;

            DataGridView datagridview = new DataGridView();
            datagridview.DataSource = bSource;
            return datagridview;
        }

        public void deleteMovie(string movieName)
        {
            try
            {

                dBConnect = new DBConnect();
                MySqlCommand mysqlcmd = new MySqlCommand("deleteMovie", dBConnect.connection);
                mysqlcmd.CommandType = CommandType.StoredProcedure;
                mysqlcmd.Parameters.AddWithValue("_movieName", movieName);
                mysqlcmd.ExecuteNonQuery();
                MessageBox.Show("Successfully deleted the movie");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
       public DataTable getMovieNames()
        {
            DBConnect dBConnect = new DBConnect();

            MySqlDataAdapter sqldata = new MySqlDataAdapter("getMovieNames", dBConnect.connection);
            sqldata.SelectCommand.CommandType = CommandType.StoredProcedure;
            
            DataTable dttable = new DataTable();
            sqldata.Fill(dttable);
            return dttable;
        }
        public DataTable getDataForChart()
        {
            DBConnect dBConnect = new DBConnect();

            MySqlDataAdapter sqldata = new MySqlDataAdapter("getDataForChart", dBConnect.connection);
            sqldata.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable dttable = new DataTable();
            sqldata.Fill(dttable);
            return dttable;
        }

    }
}
