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
using Hack.Utilities;
using System.Configuration;
using Npgsql;

namespace Hack
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        String Username;
        String usernamesmall;
        string name;
        public Register(String username)
        {
            InitializeComponent();
            name = username;
            Trace.WriteLine(username);
            userNameBox.Content = username;
            Username = username.ToUpper();
            loginUsername.Content = username;
            usernamesmall = username;
                        
        }
        public Register()
        {
            InitializeComponent();
        }
        

        private void submitBtn(object sender, RoutedEventArgs e)
        {
            String password = passwordBox.Password.ToString();
            String cpassword = cpasswordBox.Password.ToString();
            Trace.WriteLine(cpasswordBox.Password.ToString());

            String id = System.Guid.NewGuid().ToString();
            Console.WriteLine(id);

            var connect = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

            using (var conn = new NpgsqlConnection(connect))
            {
                try
                {
                    conn.Open();
                    //Trace.WriteLine("connection opened!!");

                    using (var cmd = new NpgsqlCommand("SELECT * FROM register WHERE name='" + Username + "';", conn))
                    using (var reader = cmd.ExecuteReader())
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                               // Guid id = reader.GetGuid(0);
                                String name = reader.GetString(1);
                                {
                                    if (Username == name)
                                    {
                                        Trace.WriteLine("user already present!!");
                                        var result = MessageBox.Show("User already exists try logging in.", "Info", MessageBoxButton.OK);
                                        if (result == MessageBoxResult.OK)
                                        {
                                        passwordBox.Clear();
                                        cpasswordBox.Clear();
                                            
                                            // login.Show();

                                        }
                                    }
                                    else
                                    {
                                        Personaldetails pd = new Personaldetails(usernamesmall);
                                        pd.Show();
                                        this.Close();
                                    }

                                }
                            }
                        }
                        else
                        {
                            reader.Close();

                            if (password != cpassword)
                            {
                                //submitButton.Visibility = Visibility.Visible;
                                notMatching1.Content = "passwords did not match";
                            }
                            else
                            {
                                // String encryptedPassword = Encrypt.Encryptdata(password);
                                //Trace.WriteLine(encryptedPassword);
                                String encryptedPassword = PasswordAuth.EncryptString(password);
                                Trace.WriteLine(encryptedPassword);

                                var cmdInsert = new NpgsqlCommand("INSERT INTO register (id,name,password) VALUES ('" + id + "','" + Username + "','" + encryptedPassword + "');", conn);


                                cmdInsert.ExecuteNonQuery();
                                //  Trace.WriteLine("inserted!");
                                //MessageBox.Show("registered!!");
                                var result = MessageBox.Show("Registered", "Info", MessageBoxButton.OK);
                                if (result == MessageBoxResult.OK)
                                {

                                    Personaldetails pd = new Personaldetails(usernamesmall);
                                    pd.Show();
                                    this.Close();

                                }

                            }
                        }

                    //  Trace.WriteLine("........");

                    conn.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                }

         
        }

        private void loginClick(object sender, RoutedEventArgs e)
        {
            var connect = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            // String connString = DbConnection.Connect();
            using (var conn = new NpgsqlConnection(connect))
            {
                try
                {


                    conn.Open();
                    Trace.WriteLine("conn opened!");
                    using (var cmd = new NpgsqlCommand("SELECT password FROM register WHERE name='" + Username + "';", conn))
                    using (var reader = cmd.ExecuteReader())

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {

                                String password = reader.GetString(0);
                                // String encryptedPassword = Encrypt.Encryptdata(password);
                                //   String decryptedPassword = Decrypt.Decryptdata(password);
                                // Trace.WriteLine(decryptedPassword);
                                String usertypedPassword = PasswordAuth.EncryptString(loginPasswordbox.Password.ToString());
                                Trace.WriteLine(usertypedPassword);

                             {
                                    if (password == usertypedPassword)
                                    {

                                        MessageBox.Show("Login success!");
                                         features fts = new features(usernamesmall);
                                    //usertext.Text = userName;
                                    
                                    fts.Show();
                                    this.Close();  
                                       
                                        
                                    }
                                    else
                                    {
                                        MessageBox.Show("password is wrong!!!!", "error");
                                        Register rg = new Register(usernamesmall);
                                        rg.Show();
                                        this.Close();
                                    }


                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("User is not registered!");
                            Register rg = new Register(usernamesmall);
                            rg.Show();
                            this.Close();
                        }
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
