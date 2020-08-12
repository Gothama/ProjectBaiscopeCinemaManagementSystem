using BookShopManagement.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BookShopManagement.UserControls;
using BookShopManagement.Classes;

namespace BookShopManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String username = txtUsername.Text;
            String password = txtPassword.Text;
            DBConnect h = new DBConnect();
            string k = h.SignIn(username, password);
            if(k.Equals("C"))
            {
                Form_Dashboard fd = new Form_Dashboard(username, password);
                {
                    fd.ShowDialog();
                }
            }
            else if (k.Equals("S"))
            {
                Form_Dashboard_Staff fd = new Form_Dashboard_Staff(username, password);
                {
                    fd.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Wrong Credentials");
            }
            
        }

        private void label8_Click(object sender, EventArgs e)
        {
            SignUp uch = new SignUp();
            uch.Show();
        }

        private void btnTicketScanner_Click_1(object sender, EventArgs e)
        {
            QRCodeScanner qRCodeScanner = new QRCodeScanner();
            qRCodeScanner.ShowDialog();
        }

        
    }
}
