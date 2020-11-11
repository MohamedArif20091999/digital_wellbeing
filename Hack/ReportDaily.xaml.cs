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
using Npgsql;
using System.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Controls.DataVisualization.Charting;

namespace Hack
{
    /// <summary>
    /// Interaction logic for ReportDaily.xaml
    /// </summary>
    public partial class ReportDaily : Window
    {
        string p1name = "";
        public ReportDaily(string proname)
        {
            InitializeComponent();
            p1name = proname;
        }
        


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((ColumnSeries)mcChart.Series[0]).ItemsSource = new KeyValuePair<string, int>[]{
            new KeyValuePair<string, int>("Nov 1", 60),
            new KeyValuePair<string, int>("Nov 2", 100),
            new KeyValuePair<string, int>("Nov 3", 75),
            new KeyValuePair<string, int>("Nov 4", 50),
            new KeyValuePair<string, int>("Nov 5", 25),
            };
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ((ColumnSeries)mcChart.Series[0]).ItemsSource = new KeyValuePair<string, int>[]{
            new KeyValuePair<string, int>("Nov 1", 60),
            new KeyValuePair<string, int>("Nov 2", 100),
            new KeyValuePair<string, int>("Nov 3", 75),
            new KeyValuePair<string, int>("Nov 4", 50),
            new KeyValuePair<string, int>("Nov 5", 25),
            };
        }

        private void profile_Click(object sender, RoutedEventArgs e)
        {
            string id = "";
            Profile profile = new Profile(p1name);
            profile.pname.Content = p1name;
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            features fts = new features(p1name);
            fts.Show();
            this.Close();
        }
    }
}
