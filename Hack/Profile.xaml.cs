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

namespace Hack
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        string proname = "";
        public Profile(string uname)
        {
            InitializeComponent();
            proname = uname;
            pname.Content = proname;
        }

        
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
