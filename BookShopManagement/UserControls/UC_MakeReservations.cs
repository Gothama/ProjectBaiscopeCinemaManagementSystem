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
    public partial class UC_MakeReservations : UserControl
    {
        public string NIC;
        private BookATicket bk;

        public UC_MakeReservations(string NIC)
        {
            InitializeComponent();
            this.NIC = NIC;
            Movies m = new Movies();
            comboBox1.DataSource =  m.getMovieNames();
            comboBox1.DisplayMember = "movieName";
            comboBox2.SelectedIndex = 0;

        }
        
        private void bookedSeats()
        {
          
            Button[] btnArray = { button2, button4, button18, button17, button26, button25, button34, button33,
                button5, button6, button16, button15, button24, button23,button32, button31};
            DBConnect dBConnect = new DBConnect();

            string movieName = comboBox1.Text;
            DateTime date = Convert.ToDateTime(dateTimePicker1.Value);
            string timeSlot = comboBox2.Text;
            
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
            for(int k = 0; k<btnArray.Length; k++)
            {
                btnArray[k].BackColor = Color.FromArgb(0, 192, 0);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                btnArray[Convert.ToInt16(dr["seatNum"])-1].BackColor = Color.Red;
            }
        }
        private void btnReserveASeat_Click(object sender, EventArgs e)
        {
            try
            {
                int seatNum = Convert.ToInt16(txtSeatNum.Text);
                bk = new BookATicket(seatNum, comboBox1.Text,NIC , "1000", dateTimePicker1.Value, comboBox2.Text);
                bk.makeTicket();
            }
            catch(Exception k)
            {
                MessageBox.Show("Select the Seat","Error" , MessageBoxButtons.RetryCancel , MessageBoxIcon.Error);
            }
            
        }
        private void getNumber(int seat , Color c)
        {
            if(c == Color.Red)
            {
                MessageBox.Show("This is already booked" , "Error" , MessageBoxButtons.OK ,MessageBoxIcon.Error);
            }
            else
            {
                txtSeatNum.Text = seat.ToString();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            getNumber(1 , button2.BackColor);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            getNumber(2, button4.BackColor);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            getNumber(3, button18.BackColor);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            getNumber(4, button17.BackColor);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            getNumber(5, button26.BackColor);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            getNumber(6, button25.BackColor);
        }

        private void button34_Click(object sender, EventArgs e)
        {
            getNumber(7, button34.BackColor);
        }

        private void button33_Click(object sender, EventArgs e)
        {
            getNumber(8, button33.BackColor);
        }

        private void btnETicket_Click(object sender, EventArgs e)
        {
            bk.ticketEmail();
        }

        private void btnQRCode_Click(object sender, EventArgs e)
        {
           pictureBox2.Image =  bk.getTicketQRCode();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            getNumber(9, button5.BackColor);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            getNumber(10, button6.BackColor);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            getNumber(11, button16.BackColor);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            getNumber(12, button15.BackColor);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            getNumber(13, button24.BackColor);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            getNumber(14, button23.BackColor);
        }

        private void button32_Click(object sender, EventArgs e)
        {
            getNumber(15, button32.BackColor);
        }

        private void button31_Click(object sender, EventArgs e)
        {
            getNumber(16, button4.BackColor);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            bookedSeats();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bookedSeats();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            bookedSeats();
        }

        private void UC_MakeReservations_Load(object sender, EventArgs e)
        {
            bookedSeats();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //bookedSeats();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            bookedSeats();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Ticket n = new Ticket(comboBox1.Text, txtSeatNum.Text,comboBox2.Text,dateTimePicker1.ToString());
            //string movieName, string seatNum,string showTime, string date
            n.Show();
        }
    }
}
