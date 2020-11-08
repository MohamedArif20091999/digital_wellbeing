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
        public WaterIntake()
        {
            InitializeComponent();
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
            features fts = new features();
            fts.Show();
            this.Close();
        }
    }
}
