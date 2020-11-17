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
        //private void signout_Click(object sender, RoutedEventArgs e)
        //{

        //}

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
       
        private void gamesClick(object sender, RoutedEventArgs e)
        {
            GameWindow w = new GameWindow();
            List<string> s = new List<string>() {"https://www.improvememory.org/wp-content/games/blink/index.html","https://elgoog.im/breakout/", "https://www.google.com/fbx?fbx=snake_arcade", 
      "https://poki.com/en/g/cut-the-rope?campaign=11288057741&adgroup=113657985991&target=&location=1007809&creative=471067326172&placement=www.improvememory.org&gclid=EAIaIQobChMI1M3ww8T67AIVzRGtBh1cqwIlEAEYASACEgL9MfD_BwE", "https://www.improvememory.org/wp-content/games/tronix-2/index.html" };
            Random rnd = new Random();
            int rand = rnd.Next(0, 5);
            System.Diagnostics.Process.Start(s[rand]);
        
        }

        private void eyeExercise(object sender, RoutedEventArgs e)
        {
            List<string> s = new List<string>() {"https://youtu.be/t4X3dhvSw5I","https://youtu.be/DPg0x_nVPXg", "https://youtu.be/GCp28KYQzrE", "https://youtu.be/B45KX7lzyjs"};
            Random rnd = new Random();
            int rand = rnd.Next(0, 4);
            // String st= s[rand];
            System.Diagnostics.Process.Start(s[rand]);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void setTime(object sender, RoutedEventArgs e)
        {
            SetTime st = new SetTime();
            st.Show();
            this.Close();
        }
    }
}
