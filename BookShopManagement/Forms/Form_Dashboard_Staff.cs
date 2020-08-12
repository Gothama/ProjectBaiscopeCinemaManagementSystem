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
    public partial class Form_Dashboard_Staff : Form
    {
        int PanelWidth;
        bool isCollapsed;
        Account ac;
        public Form_Dashboard_Staff(String username , String password)
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
            AddControlsToPanel(uch);
        }
        public Form_Dashboard_Staff()
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

        private void Form_Dashboard_Staff_Load(object sender, EventArgs e)
        {

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
            UC_Home uch = new UC_Home(globalvariables.password, globalvariables.username);
            AddControlsToPanel(uch);
        }

        private void btnReservations_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnReservations);
            UC_MakeReservations us = new UC_MakeReservations("Admin");
            AddControlsToPanel(us);
        }

        private void btnMovies_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnMovies);
            UC_AddMovies up = new UC_AddMovies();
            AddControlsToPanel(up);
        }

        private void btnRevenue_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnRevenue);
            UC_ManageExpense ea = new UC_ManageExpense();
            AddControlsToPanel(ea);
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnCustomers);
            UC_ManageUser um = new UC_ManageUser();
            AddControlsToPanel(um);
        }

        private void btnViewSales_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnViewSales);
            UC_TotalRevenue vs = new UC_TotalRevenue();
            AddControlsToPanel(vs);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnAbout);
            UC_StaffAccount vs = new UC_StaffAccount();
            AddControlsToPanel(vs);
        }

        private void timerTime_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            labelTime.Text = dt.ToString("hh:mm:ss");
        }

        
    }
}
