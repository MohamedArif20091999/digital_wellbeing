using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for Personaldetails.xaml
    /// </summary>
    public partial class Personaldetails : Window
    {
        public Personaldetails(string username)
        {
            InitializeComponent();
            userNameLabel.Content = username;
        }

        private void submitBtnClick(object sender, RoutedEventArgs e)
        {
            String id="default";
            String gender="default";
            //string date = datePicker.Text;
            string date = Convert.ToDateTime(datePicker.Text).ToString("yyyy-MM-dd");

            //DateTime Date = new DateTime(long.Parse(date));
            //Trace.WriteLine(DateTime.Parse(date));
            //Trace.WriteLine(date.GetType());
            if (maleRadio.IsChecked == true) gender = maleRadio.Content.ToString();
            if (femaleRadio.IsChecked == true) gender = femaleRadio.Content.ToString();
            Trace.WriteLine(gender);
            int weight =Int32.Parse(weightBox.Text);
            
            
            
            var userName = userNameLabel.Content.ToString();
            var connect = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            using (var conn = new NpgsqlConnection(connect))
            {
                try
                {


                    conn.Open();
                    using (var cmd = new NpgsqlCommand("SELECT id FROM register WHERE name='" + userName.ToUpper() + "';", conn))
                    using (var reader = cmd.ExecuteReader())
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {

                                //int id = reader.GetInt32(0);
                               id = reader.GetString(0);
                                Trace.WriteLine(id);
                                // reader.Close();
                            }
                            reader.Close();
                        }

                    var cmdInsert = new NpgsqlCommand("INSERT INTO personaldetails (id,gender,dob,weight) VALUES ('" + id + "','" + gender + "','" + date + "'," + weight + ");", conn);
                    Trace.WriteLine(cmdInsert);
                    cmdInsert.ExecuteNonQuery();
                    //Trace.WriteLine("Done!!");
                    conn.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    
                }
            }
            


        }
    }
}
