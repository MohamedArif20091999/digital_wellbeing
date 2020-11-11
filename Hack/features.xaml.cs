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

        public features()
        {

            InitializeComponent();
        }
            string uname = "";
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ReportDaily rd = new ReportDaily();
            rd.Show();
            this.Close();
        }

        private void profile_Click(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile(uname);
            /*var connect = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

            using (var conn = new NpgsqlConnection(connect))
            {
                try
                {
                    conn.Open();
                    //Trace.WriteLine("connection opened!!");

                    using (var cmd = new NpgsqlCommand("SELECT * FROM register WHERE name='" + uname + "';", conn))
                    using (var reader = cmd.ExecuteReader())
                       while (reader.Read())
                            {
                                Guid id = reader.GetGuid(0);
                                String name = reader.GetString(1);
                                {
                                    if ()
                                    {


                                    }
                                }
                            }
                        }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }*/
                
                
            profile.Show();
            this.Close();

        }
    }
}
