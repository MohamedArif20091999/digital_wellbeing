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
    /// Interaction logic for WaterIntake.xaml
    /// </summary>
    public partial class WaterIntake : Window
    {
        string proname = "";
        public WaterIntake(string uname)
        {
            InitializeComponent();
            proname = uname;
            comment.Visibility = Visibility.Hidden;
            cups.Visibility = Visibility.Hidden;
        }

        private void signout_Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void activitydd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            float pound= ((float.Parse(weight.Text) * (float)(2.205 * 0.667)) / (float)33.814);
            string water = pound.ToString();
            comment.Text = ("You have to drink "+water+" liters of water per day");
            int glass = Convert.ToInt32(Math.Floor(float.Parse(water) * 4));
            cups.Text = "This is equal to " + glass + " glsses of water";
            comment.Visibility = Visibility.Visible;
            cups.Visibility = Visibility.Visible;

        }

        private void comment_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\')[1];
            features fts = new features(userName);
            fts.Show();
            this.Close();
        }

        private void profile_Click(object sender, RoutedEventArgs e)
        {
            string id = "";
            Profile profile = new Profile(proname);
            profile.pname.Content = proname;
            var connect = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

            using (var conn = new NpgsqlConnection(connect))
            {
                try
                {
                    conn.Open();
                    //Trace.WriteLine("connection opened!!");

                    using (var cmd = new NpgsqlCommand("SELECT id FROM register;", conn))
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                        {
                            id = (reader.GetString(0));
                        }
                    conn.Close();

                    conn.Open();
                    //String name = reader.GetString(1);
                    using (var cmd1 = new NpgsqlCommand("SELECT id,gender,dob,weight FROM personaldetails;", conn))
                    using (var reader1 = cmd1.ExecuteReader())
                        while (reader1.Read())
                        {
                            string perid = reader1.GetString(0);
                            string gend = reader1.GetString(1);
                            var dob = reader1.GetDate(2);
                            int weight = reader1.GetInt32(3);
                            if (id == perid)
                            {
                                profile.gender.Content = gend;
                                profile.dob.Content = dob;
                                profile.weight.Text = weight.ToString();
                            }
                        }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


            profile.Show();
            this.Close();
        }
    }
}
