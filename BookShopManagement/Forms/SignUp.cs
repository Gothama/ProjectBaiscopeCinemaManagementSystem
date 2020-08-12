using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookShopManagement.UserControls;

namespace BookShopManagement.Forms
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
           
            
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            UC_SignUp signup = new UC_SignUp();
            panel1.Controls.Add(signup);
        }
        public void close()
        {
            this.Dispose();
        }
    }
}
