using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace prodavnica2
{
    internal class Konekcija
    {
        static public SqlConnection Connect()
        {
            string CS = ConfigurationManager.ConnectionStrings["home"].ConnectionString;
            SqlConnection veza = new SqlConnection(CS);
            return veza;
        }
    }
}
