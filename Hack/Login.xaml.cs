using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Npgsql;

namespace Hack
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        String user;
        public Login(String userName)
        {

            InitializeComponent();
            userNameBox.Text = userName;
            user = userName.ToUpper(); // db stores name in caps!!!
        }

        private void loginClick(object sender, RoutedEventArgs e)
        {
            String connString = DbConnection.Connect();
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT password FROM register WHERE name='" + user + "';", conn))
                using (var reader = cmd.ExecuteReader())
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                           
                            String password = reader.GetString(0);
                            {
                                if (password == passwordBox.Password.ToString())
                                {
                                
                                    MessageBox.Show("matching");
                                }
                                else
                                {
                                    MessageBox.Show("password is wrong!!!!","error");
                                }


                            }
                        }
                    }
            }
        }
    }
}
