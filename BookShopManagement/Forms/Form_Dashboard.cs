using BookShopManagement.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookShopManagement.Classes;

namespace BookShopManagement.Forms
{
    public partial class Form_Dashboard : Form
    {
        int PanelWidth;
        bool isCollapsed;
        
        public Account ac = null;
        public UC_MakeReservations uc;
        public UC_MyTickets uc1;

        public Form_Dashboard(string username, string password)
        {
            InitializeComponent();
            timerTime.Start();
            PanelWidth = panelLeft.Width;
            isCollapsed = false;
            ac = new Account(username, password);
            ac.getDetails();
            label5.Text = ac.FirstName + " " + ac.SecondName;
            globalvariables.password = password;
            globalvariables.username = username;
            UC_Home uch = new UC_Home(password, username);
            uc = new UC_MakeReservations(ac.NIC);
            uc1 = new UC_MyTickets(ac.NIC);
            AddControlsToPanel(uch);

        }
        public Form_Dashboard()
        {
            InitializeComponent();
            timerTime.Start();
            PanelWidth = panelLeft.Width;
            isCollapsed = false;
            UC_Home uch = new UC_Home();
            AddControlsToPanel(uch);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                panelLeft.Width = panelLeft.Width + 10;
                if (panelLeft.Width >= PanelWidth)
                {
                    timer1.Stop();
                    isCollapsed = false;
                    this.Refresh();
                }
            }
            else
            {
                panelLeft.Width = panelLeft.Width - 10;
                if (panelLeft.Width <= 59)
                {
                    timer1.Stop();
                    isCollapsed = true;
                    this.Refresh();
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void moveSidePanel(Control btn)
        {
            panelSide.Top = btn.Top;
            panelSide.Height = btn.Height;
        }

        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelControls.Controls.Clear();
            panelControls.Controls.Add(c);
        }
        private void btnAccount_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnAccount);
            UC_Home uch = new UC_Home(globalvariables.password,globalvariables.username);
            AddControlsToPanel(uch);
        }

        private void btnReservations_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnReservations);
            AddControlsToPanel(uc);
        }

        private void btnMovies_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnMovies);
            UC_SeeMoviesDetails up = new UC_SeeMoviesDetails();
            AddControlsToPanel(up);
        }

       

        private void btnViewSales_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnViewSales);
            
            AddControlsToPanel(uc1);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnAbout);
            UC_About vs = new UC_About();
            AddControlsToPanel(vs);

        }

        private void timerTime_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            labelTime.Text = dt.ToString("hh:mm:ss");
        }

        
    }
}
