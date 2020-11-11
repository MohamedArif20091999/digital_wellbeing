using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Diagnostics;
using Hack.services;
using System.Configuration;

namespace Hack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            //Dbservice.connection();
           
            Dbconnection.Connect();
            Trace.WriteLine("connection succeeded");
            /*Thread t2 = new Thread(delegate ()
            {
                checkTime();
            });
            t2.Start();*/
            InitializeComponent();
        }

        /*private void checkTime()
        {
            
            while (true)
            {

                string time = DateTime.Now.ToString("hh:mm");
                Thread.Sleep(1000);
                if (time == "01.05")
                {
                    MessageBox.Show("Its time for your lunch!");
                    break;
                }
            }
            
        }*/

        private void registerClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\')[1];
                //  Trace.WriteLine(userName);
                Register register = new Register(userName);
                register.Show();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
          
        }

        private void loginClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\')[1];
                Login login = new Login(userName);
                login.Show();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
