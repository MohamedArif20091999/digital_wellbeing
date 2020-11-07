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
using System.Diagnostics;
using System.Configuration;
using Hack.services;

namespace Hack
{
    /// <summary>
    /// Interaction logic for DbFailHandle.xaml
    /// </summary>
    public partial class DbFailHandle : Window
    {
        public DbFailHandle()
        {
            InitializeComponent();
        }

        private void submitClick(object sender, RoutedEventArgs e)
        {
            // < add name = "conn"  connectionString = "Server=127.0.0.1;Port=5432;Database=postgres;User Id=postgres;Password=bee;" />
            String password = passwordBox.Password.ToString();
            string connStr = "Server=127.0.0.1;Port=5432;Database=postgres;User Id=postgres;Password=" + password + ";";
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            connectionStringsSection.ConnectionStrings["conn"].ConnectionString = connStr;
            config.Save();
            ConfigurationManager.RefreshSection("connectionStrings");
            Trace.WriteLine(connectionStringsSection.ConnectionStrings["conn"]);
            //  MainWindow mw = new MainWindow();
            // mw.Show();
            this.Close();
            Dbconnection.Connect();
        }
    }
}
