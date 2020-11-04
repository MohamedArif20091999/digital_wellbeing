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
    /// Interaction logic for WaterLevel.xaml
    /// </summary>
    public partial class WaterLevel : Window
    {
        //string userName;
        public WaterLevel(string username)
        {
            InitializeComponent();
            //userName = username;
        }
        public WaterLevel()
        {
            InitializeComponent();
            //userName = username;
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            
        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {
            //Register register = new Register();
            //register.Show();
            //this.Close();
        }

        private void TextBox_TextChanged_3(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Close();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
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
    }
}
