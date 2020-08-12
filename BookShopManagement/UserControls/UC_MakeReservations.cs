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

        
        private void btnReserveASeat_Click(object sender, EventArgs e)
        {
            int seatNum = Convert.ToInt16(txtSeatNum.Text);
            bk = new BookATicket(seatNum, comboBox1.Text,NIC , "1000", dateTimePicker1.Value, comboBox2.Text);
            bk.makeTicket();
        }
        private void getNumber(int seat)
        {
            txtSeatNum.Text = seat.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            getNumber(1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            getNumber(2);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            getNumber(3);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            getNumber(4);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            getNumber(5);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            getNumber(6);
        }

        private void button34_Click(object sender, EventArgs e)
        {
            getNumber(7);
        }

        private void button33_Click(object sender, EventArgs e)
        {
            getNumber(8);
        }

        private void btnETicket_Click(object sender, EventArgs e)
        {
            bk.ticketEmail();
        }

        private void btnQRCode_Click(object sender, EventArgs e)
        {
           pictureBox2.Image =  bk.getTicketQRCode();
        }
    }
}
