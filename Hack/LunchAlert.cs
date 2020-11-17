using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Hack
{
    class LunchAlert
    {
        public static void Window(String time)
        {
           // String time = "ab";
            String uHour = "cd";
            String uMinutes = "ef";
            String cHour = "gh";
            String cMinute = "ij";
           
       
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
    }
}
