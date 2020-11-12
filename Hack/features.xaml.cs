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
using System.Diagnostics;
using System.Windows.Controls.DataVisualization.Charting;
using NpgsqlTypes;

namespace Hack
{
    /// <summary>
    /// Interaction logic for features.xaml
    /// </summary>
    public partial class features : Window
    {

        
        string uname = "";
        public features(string username)
        {
            
            InitializeComponent();
            uname = username;
            namelbl.Content = uname+"!";
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WaterIntake wi = new WaterIntake(uname);
            var connect = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            Trace.WriteLine(connect);

            using (var conn = new NpgsqlConnection(connect))
            {
                try
                {
                    conn.Open();
                    //Trace.WriteLine("connection opened!!");
                    string query = "INSERT INTO waterintake(activity,workpm) VALUES('sedentary',0);" +
                        "INSERT INTO waterintake(activity,workpm) VALUES('light activity',2);" +
                        "INSERT INTO waterintake(activity,workpm) VALUES('moderately active',3);" +
                        "INSERT INTO waterintake(activity,workpm) VALUES('highly active',4);";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                wi.activitydd.Items.Add("sedentary");
                wi.activitydd.Items.Add("light activity");
                wi.activitydd.Items.Add("moderately active");
                wi.activitydd.Items.Add("highly active");
                /*try
                {
                    conn.Open();
                    string query = "SELECT * FROM waterintake";

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
                }*/
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
            ReportDaily rd = new ReportDaily(uname);
            ((ColumnSeries)rd.mcChart.Series[0]).ItemsSource = new KeyValuePair<string, int>[]{
            new KeyValuePair<string, int>("Nov 1", 60),
            new KeyValuePair<string, int>("Nov 2", 100),
            new KeyValuePair<string, int>("Nov 3", 75),
            new KeyValuePair<string, int>("Nov 4", 50),
            new KeyValuePair<string, int>("Nov 5", 25),
            };
            rd.Show();
            this.Close();
        }

        private void profile_Click(object sender, RoutedEventArgs e)
        {
            string id = "";
            Profile profile = new Profile(uname);
            profile.pname.Content = uname;
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
