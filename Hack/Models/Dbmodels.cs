using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Diagnostics;

namespace Hack.Models
{
    class Dbmodels
    {

        public static void CreateDb()
        {
            var connect = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            var conn = new NpgsqlConnection(connect);
            {
                conn.Open();
                var cmdCDb = new NpgsqlCommand("CREATE DATABASE digitalwellbeing;", conn);
                cmdCDb.ExecuteNonQuery();
                Trace.WriteLine("Db ready!!");
                conn.Close();

            }
        }
        public static void CreateTable()
        {
            var connect = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

            using (var conn = new NpgsqlConnection(connect))
            {
                conn.Open();
                var cmdCTb = new NpgsqlCommand("CREATE TABLE register (id uuid DEFAULT uuid_generate_v4 (),name TEXT NOT NULL,password TEXT NOT NULL,PRIMARY KEY (id));", conn);
                // var pdTable = new NpgsqlCommand("CREATE TABLE personaldetails (id TEXT,gender TEXT NOT NULL,dob DATE NOT NULL,weight INT NOT NULL)");
                cmdCTb.ExecuteNonQuery();
                Trace.WriteLine("table ready!!");
                conn.Close();
            }
            var connec = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

            using (var conn = new NpgsqlConnection(connec))
            {
                conn.Open();
                var cmdpd = new NpgsqlCommand("CREATE TABLE personaldetails (id uuid,gender TEXT NOT NULL,dob DATE NOT NULL,weight INT NOT NULL);", conn);
                cmdpd.ExecuteNonQuery();
                Trace.WriteLine("table ready!!");
                conn.Close();


            }
        }
    }
}
