using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookShopManagement.Classes;

namespace BookShopManagement.Forms
{
    public partial class Form_AddNewMovie : Form
    {
        
        public Form_AddNewMovie()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Movies movies = new Movies();
            if(txtMovieTitle.Text.ToString() != "" && datePickerMovieReleasedDate.Value.ToString("yyyy") != " " && comboMovieType.Text.ToString()!="" && txtTrailerLink.Text.ToString() != "")
            {
                try
                {
                   movies.addMovieToDataBase( txtMovieTitle.Text.ToString(), datePickerMovieReleasedDate.Value.ToString("yyyy"), comboMovieType.Text.ToString(), txtTrailerLink.Text.ToString());
                }
                catch(Exception ew)
                {
                    MessageBox.Show(ew.Message);
                }
            }
            else
            {
                MessageBox.Show("Pls Fill All the fields");
            }
           
           
            
        }

      
        private void txtTrailerLink_Leave(object sender, EventArgs e)
        {
            Regex mRegxExpression;
            if (txtTrailerLink.Text.Trim() != string.Empty)
            {
                mRegxExpression = new Regex(@"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)?[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$");

                if (!mRegxExpression.IsMatch(txtTrailerLink.Text.Trim()))
                {
                    MessageBox.Show("Trailer Link format is not correct.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTrailerLink.Focus();
                }
            }
        }

        
    }
}
