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

namespace BookShopManagement.UserControls
{
    public partial class UC_StaffAccount : UserControl
    {
        Movies m = new Movies();
        public UC_StaffAccount()
        {
            InitializeComponent();
            chart1.DataSource = m.getDataForChart();
            chart1.Series["Movies"].XValueMember = "COUNT(movieName)";
            chart1.Series["Movies"].YValueMembers = "movieName";
            chart1.Titles.Add("Movie Chart");
        }
        
    }
}
