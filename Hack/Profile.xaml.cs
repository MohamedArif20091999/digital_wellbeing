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
using Npgsql;
using System.Data;
using System.Windows.Shapes;

namespace Hack
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        string proname = "";
        public Profile(string uname)
        {
            InitializeComponent();
            proname = uname;
            pname.Content = proname;
            updatebt.Visibility = Visibility.Hidden;
        }

        
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            weight.Text = "";
            updatebt.Visibility = Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            features fts = new features(proname);
            fts.Show();
            this.Close();
        }

        

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var connect = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

            using (var conn = new NpgsqlConnection(connect))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE personaldetails SET weight='" + weight.Text.ToString() + "';";
                    NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                    NpgsqlDataReader dr = cmd.ExecuteReader();
                    MessageBox.Show("Updated!");
                    updatebt.Visibility = Visibility.Hidden;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
