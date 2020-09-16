using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShopManagement.Forms
{
    public partial class Ticket : Form
    {
        private string movieName, seatNum, showTime, date;

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        public Ticket(string movieName, string seatNum,string showTime, string date)
        {
            InitializeComponent();
            this.movieName = movieName;
            this.seatNum = seatNum;
            this.showTime = showTime;
            this.date = date;

            CrystalReport1 cr = new CrystalReport1();
            TextObject text1 = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["movieName"];
            text1.Text = movieName;

            TextObject text2 = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["showTime"];
            text2.Text = showTime;

            TextObject text3 = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["seatNum"];
            text3.Text = seatNum;

            TextObject text4 = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["date"];
            text4.Text = date;

            crystalReportViewer1.ReportSource = cr;
        }
    }
}
