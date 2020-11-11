using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hack
{
    class Frequentalert
    {
        public static void checkTime()
        {
            Process process = new Process();
            process.StartInfo.FileName = "powershell.exe";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            process.StandardInput.WriteLine("$StartDay=(Get-Date).AddDays(-1)");
            process.StandardInput.WriteLine("(Get-EventLog -Logname System -InstanceID 1 -Newest 1 -After $StartDay[0] |Select-Object TimeWritten|fl)");
            process.StandardInput.Flush();
            process.StandardInput.Close();
            // Console.WriteLine(process.StandardOutput.ReadToEnd());
            //Console.ReadKey();
            process.WaitForExit();
            string store = "ds";
            String log = process.StandardOutput.ReadToEnd();
            Console.WriteLine(log);
            string[] array = log.Split(new string[] { "TimeWritten : " }, StringSplitOptions.None);
            foreach (string value in array)
            {
                Console.WriteLine(value);
                store = value;
            }
            store.Replace(@"\r", "\r");
            String stote2 = "a";
            string[] arra = store.Split(new string[] { "\r" }, StringSplitOptions.None);
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine(arra[i]);
                stote2 = arra[i];
            }
            //String logs = log.Substring(383, 25);
            stote2 = stote2.Substring(0, stote2.Length - 3);
            Console.WriteLine(stote2);


            //  Console.WriteLine(lon.Count);
            DateTime dateTime1 = Convert.ToDateTime(stote2);

            //  DateTime da = new DateTime();
            //Console.WriteLine(dateTime1.AddMinutes(1));
            DateTime updatedTime = dateTime1.AddMinutes(30);
            while (true)
            {
                 //string time = DateTime.Now.ToString("hh:mm");
                //Thread.Sleep(1000);
                if (dateTime1 == updatedTime)
                {
                    Console.WriteLine("Alert Here!!");
                    updatedTime = updatedTime.AddMinutes(30);
                }
                Thread.Sleep(60000);
                dateTime1 = dateTime1.AddMinutes(1);
                //Trace.WriteLine(dateTime1);
            }
        }

    }
}
