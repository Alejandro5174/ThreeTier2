using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos1
{
    public class DALconexion
    {
        public class Conexion
        {
            public SqlConnection cn = new SqlConnection(
            "Server=.\\SQLEXPRESS;Database=DBFACTURAS;Integrated Security=true");
        }
    }
}
