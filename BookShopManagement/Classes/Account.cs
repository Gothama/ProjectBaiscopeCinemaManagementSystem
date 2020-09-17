using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace BookShopManagement.Classes
{
    public class Account : DBConnect
    {
        private String email;
        private string firstName;
        private string secondName;
        private string password;
        private string username;
        private string accType;
        private string nIC;

        public string FirstName { get => firstName; set => firstName = value; }
        public string SecondName { get => secondName; set => secondName = value; }
        public string Password { get => password; set => password = value; }
        public string Username { get => username; set => username = value; }
        public string AccType { get => accType; set => accType = value; }
        public string NIC { get => nIC; set => nIC = value; }
        public string Email { get => email; set => email = value; }

        public Account(string firstName, string secondName, string password, string username, string accType, string nIC , string email)
        {
            FirstName = firstName;
            SecondName = secondName;
            Password = password;
            Username = username;
            AccType = accType;
            NIC = nIC;
            Email = email;
        }

        public Account(string username, string password)
        {
           
            Password = password;
            Username = username;
            
        }
        public void createAccount()
        {
            try {

                this.password = encrypt(password);
                MySqlCommand mysqlcmd = new MySqlCommand("createUserAccount", connection);
                mysqlcmd.CommandType = CommandType.StoredProcedure;
                mysqlcmd.Parameters.AddWithValue("_NIC", NIC);
                mysqlcmd.Parameters.AddWithValue("_FirstName", FirstName);
                mysqlcmd.Parameters.AddWithValue("_SecondName", SecondName);
                mysqlcmd.Parameters.AddWithValue("_AccType", AccType);
                mysqlcmd.Parameters.AddWithValue("_Email", Email);
                mysqlcmd.Parameters.AddWithValue("_Password", Password);
                mysqlcmd.Parameters.AddWithValue("_Username", Username);
                mysqlcmd.ExecuteNonQuery();
                MessageBox.Show("Account Created" , "Successfull", MessageBoxButtons.OK , MessageBoxIcon.Information);
                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error" , MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
            }

        }
        public void getDetails()
        {
            try
            {
                string sql = "SELECT * FROM cinemamanagementsystem.logindetails WHERE Username= '" + username + "'";
                MySqlCommand mysqlcommand = connection.CreateCommand();
                mysqlcommand.CommandText = sql;
                MySqlDataReader reader = mysqlcommand.ExecuteReader();
                while (reader.Read())
                {
                    NIC = reader.GetString(0);
                    FirstName = reader.GetString(1);
                    SecondName = reader.GetString(2);
                    Email = reader.GetString(4);
                    
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            
        }
        

        public string encrypt(string e)
        {
            string d = Eramake.eCryptography.Encrypt(e) ;
            return d;
        }
        
    }
}
