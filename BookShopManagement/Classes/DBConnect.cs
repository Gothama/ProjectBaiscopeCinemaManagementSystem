using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace BookShopManagement.Classes
{
    public class DBConnect
    {
        public MySqlConnection connection = new MySqlConnection("server=localhost;database=cinemamanagementsystem;uid=root;pwd=12345");
        public DBConnect()
        {
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        public string SignIn(String username , String password )
        {
           
            int i = 0;
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            try
            {
                password = Encrypt(password);
                string accT = "C";
                cmd.CommandText = "SELECT * FROM cinemamanagementsystem.logindetails where Username='" + username + "' and Password= '" + password + "'and AccType='" + accT + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());

                if (i == 1)
                {

                    return "C";
                }
                else
                {
                    accT = "S";
                    cmd.CommandText = "SELECT * FROM cinemamanagementsystem.logindetails where Username='" + username + "' and Password= '" + password + "'and AccType = '" + accT + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt1 = new DataTable();
                    MySqlDataAdapter da1 = new MySqlDataAdapter(cmd);
                    da1.Fill(dt1);
                    i = Convert.ToInt32(dt1.Rows.Count.ToString());

                    if (i == 1)
                    {

                        return "S";
                    }
                    else
                    {
                        return "B";
                    }
                }
            }
            catch (Exception e)
            {
                
                    return "B";
                
            }
            
           
        }
        public string Encrypt(string d)
        {
            string e = Eramake.eCryptography.Encrypt(d);
            return e;
        }

    }
}
