using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Hack.Models;
using Npgsql;

namespace Hack.services
{
    class Dbconnection
    {
        public static void Connect()
        {
            try
            {
                var connect = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
                //String connString = DbConnection.Connect();
                Trace.WriteLine(connect);
                var conn = new NpgsqlConnection(connect);
                conn.Open();
                Trace.WriteLine("conn opened!");

                using (var cmd = new NpgsqlCommand("SELECT * FROM register;", conn))
                using (var reader = cmd.ExecuteReader())

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            Trace.WriteLine("established");

                        }
                    }
                    else
                    {
                        Trace.WriteLine("exist but empty!");
                    }
            }
            catch (NpgsqlException ex)
            {
                 if (ex.GetBaseException() is PostgresException pgException)
                 {
                    if (pgException.SqlState == "28P01")
                    {
                        var res = MessageBox.Show("Password Auth failed..Try resetting it.", "Info", MessageBoxButton.OK);
                        if (res == MessageBoxResult.OK)
                        {
                            DbFailHandle dbf = new DbFailHandle();
                            dbf.ShowDialog();
                        }
                    }
                    else if (pgException.SqlState == "3D000")
                    {
                        MessageBox.Show("Database does not exist!!");
                        // Dbmodels.CreateDb();


                    }
                    else if (pgException.SqlState == "42P01")
                    {
                        // MessageBox.Show("Table relation does not exists!!");
                        Dbmodels.CreateTable();
                        Trace.WriteLine("Done!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

                    }                   
                 }

                 
           
                
            }
          
        }
       

    }
}
