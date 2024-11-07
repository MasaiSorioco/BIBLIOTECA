using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_DATOS
{
    public class Conexion
    {
        private readonly string connectionString = "Data Source=DESKTOP-AS3NDO4\\MMS;Initial Catalog=BDBiblioteca;Integrated Security=True";

        public SqlConnection Conectar()
        {
            return new SqlConnection(connectionString);
        }
    }
}
