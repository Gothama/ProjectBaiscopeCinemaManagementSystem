using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShopManagement.Classes
{
    class BookATicket
    {
        private int seatNum;
        private String movieName, cusNIC, price;
        private DateTime date;
        private string timeSlot;

        DBConnect dBConnect;
        
        public BookATicket( int seatNum, string movieName,  string cusNIC, string price, DateTime date, string timeSlot)
        {
          
            this.seatNum = seatNum;
            this.movieName = movieName;
           
            this.cusNIC = cusNIC;
            this.price = price;
            this.date = date;
            this.timeSlot = timeSlot;
        }

        public void makeTicket()
        {
            try { 

            dBConnect = new DBConnect();
            MySqlCommand mysqlcmd = new MySqlCommand("BookATicket", dBConnect.connection);
            mysqlcmd.CommandType = CommandType.StoredProcedure;
            mysqlcmd.Parameters.AddWithValue("_seatNum", seatNum);
            mysqlcmd.Parameters.AddWithValue("_movieName", movieName);
            mysqlcmd.Parameters.AddWithValue("_cusNIC", cusNIC);
            mysqlcmd.Parameters.AddWithValue("_price", price);
            mysqlcmd.Parameters.AddWithValue("_date", date);
            mysqlcmd.Parameters.AddWithValue("_timeSlot", timeSlot);
            mysqlcmd.ExecuteNonQuery();
            MessageBox.Show("Successfully reseaved a ticket","Successful", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch(Exception e)
            { 
                MessageBox.Show(e.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
           
        }
        public void ticketEmail()
        {
            Email ticketEmailing = new Email();
            ticketEmailing.send("You Have successfully researved a ticket");
        }
        public Image getTicketQRCode()
        {

            QRCodeGenerate ticketQR = new QRCodeGenerate();
            return ticketQR.ticketQRCode("Gothama", movieName,date.ToString(), timeSlot);
        }
        public DataTable getSeatNumbers(string movieName, DateTime date ,string timeSlot)
        {
            DBConnect dBConnect = new DBConnect();

            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            cmd = new MySqlCommand("getSeatNumbers", dBConnect.connection);
            cmd.Parameters.Add(new MySqlParameter("_movieName", movieName));
            cmd.Parameters.Add(new MySqlParameter("_date", date));
            cmd.Parameters.Add(new MySqlParameter("_timeSlot", timeSlot));
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
    }
}
