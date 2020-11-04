﻿using System;
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
            int id=0;
            String gender="default";
            string date = dobBox.Text;
            //DateTime Date = new DateTime(long.Parse(date));
            Trace.WriteLine(DateTime.Parse(date));
            Trace.WriteLine(date.GetType());
            if (maleRadio.IsChecked == true) gender = maleRadio.Content.ToString();
            if (femaleRadio.IsChecked == true) gender = femaleRadio.Content.ToString();
            Trace.WriteLine(gender);
            int weight =Int32.Parse(weightBox.Text);
            
            
            
            var userName = userNameLabel.Content.ToString();
            //String connString = DbConnection.Connect();
            String connString = "Host=localhost;Username=postgres;Password=123;Database=hackathon";
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT id FROM register WHERE name='" + userName.ToUpper() + "';", conn))
                using (var reader = cmd.ExecuteReader())
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            //int id = reader.GetInt32(0);

                            //id = reader.GetInt32(0);
                            //Trace.WriteLine(id);

                           // reader.Close();
                        }
                        reader.Close();
                    }

                var cmdInsert = new NpgsqlCommand("INSERT INTO personaldetails (id,gender,dob,weight) VALUES ("+id+",'"+gender+"','"+date+"',"+weight+");", conn);

                cmdInsert.ExecuteNonQuery();
                //Trace.WriteLine("Done!!");
                MessageBox.Show("Done!!");
                WaterLevel wl = new WaterLevel(userName);
                wl.Show();
                this.Close();
                
            }


        }
    }
}
