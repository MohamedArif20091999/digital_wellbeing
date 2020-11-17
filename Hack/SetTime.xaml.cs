using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Timers;
using System.Diagnostics;



namespace Hack
{
    /// <summary>
    /// Interaction logic for SetTime.xaml
    /// </summary>
    public partial class SetTime : Window
    {
     
        
        String time="ab";
        String uHour="cd";
        String uMinutes = "ef";
        String cHour = "gh";
        String cMinute = "ij";
        

    
        public SetTime()
        {
            InitializeComponent();
            String time = TimePic.Text;
            Trace.WriteLine(time);
           // LunchAlert.Window(time);
        }
        private void submit_Click(object sender, RoutedEventArgs e)
        {
            time = TimePic.Text;
            Trace.WriteLine(time);
            String[] times = time.Split(':');
            uHour = times[0];
            uMinutes = times[1];


            while (true)
            {
                DateTime cTime = DateTime.Now;
                cHour = Convert.ToString(cTime.Hour);
                cMinute = Convert.ToString(cTime.Minute);
                if (uHour.Equals(cHour) && uMinutes.Equals(cMinute))
                {
                    Longbreak lb = new Longbreak();
                    lb.Show();
                    break;
                }
            }

        }

        //String Hour, Minute, time;

        //private void submit_Click(object sender, RoutedEventArgs e)
        //{
        //    ComboBoxItem item = combobox.SelectedItem as ComboBoxItem;
        //    //MainWindow.item.Items.Add()
        //    if (item != null)
        //    {
        //        time = item.Content.ToString();

        //        String[] timestring = time.Split(':');
        //        Hour = timestring[0];
        //        Minute = timestring[1];
        //        timer = new System.Timers.Timer();
        //        timer.Interval = 1000;
        //        timer.Elapsed += time_Elp;

        //    }
        //    else
        //    {
        //        time = combobox.Text;
        //        String[] timestring = time.Split(':');
        //        Hour = timestring[0];
        //        Minute = timestring[1];
        //        timer = new System.Timers.Timer();
        //        timer.Start();
        //        timer.Interval = 60000;
        //        timer.Elapsed += time_Elp;
        //    }

        //}
        //private void time_Elp(object sender, System.Timers.ElapsedEventArgs e)
        //{
        //    // DateTime currenttime = DateTime.Now;
        //    DateTime currenttime = DateTime.Now;
        //    String hour = Convert.ToString(currenttime.Hour);
        //    String mins = Convert.ToString(currenttime.Minute);
        //    String sec = Convert.ToString(currenttime.Second);
        //    if (Hour.Equals(hour) && Minute.Equals(mins))
        //    {
        //        try
        //        {
        //           // MessageBox.Show("the time is up");
        //            Longbreak aler = new Longbreak();
        //            aler.ShowDialog();
        //            timer.Stop();

        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //}
    }
}
