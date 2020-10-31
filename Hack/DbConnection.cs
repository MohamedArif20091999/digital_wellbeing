using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hack
{
    public  class DbConnection
    {
        public static String Connect()
        {
            var connString = "Host=localhost;Username=ariff;Password=beezz;Database=hackathon;Pooling=False";

            return connString;
        }
    }
}
