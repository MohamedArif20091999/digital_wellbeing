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
using System.Data;

namespace Hack
{
    /// <summary>
    /// Interaction logic for features.xaml
    /// </summary>
    public partial class features : Window
    {

        string uname = "AB";
        public features(string username)
        {
            
            InitializeComponent();
            uname = username;
            namelbl.Content = uname+"!";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WaterIntake wi = new WaterIntake();
            var connStr = "Host=localhost;Username=postgres;Password=123;Database=hackathon";
            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            try
            {
                conn.Open();
                string query = "SELECT * FROM activity";
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string name = dr.GetString(0);
                    wi.activitydd.Items.Add(name);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            wi.Show();
            this.Close();
        }

        private void signout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
