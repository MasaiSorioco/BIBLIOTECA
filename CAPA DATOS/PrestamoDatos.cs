using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_DATOS
{
    public class PrestamoDatos
    {
        private Conexion conexion = new Conexion();

        public void InsertarPrestamo(string tipoMaterial, string titulo, string autor, string tipoUsuario, DateTime fecha, TimeSpan hora, string nombreUsuario)
        {
            using (SqlConnection connection = conexion.Conectar())
            {
                SqlCommand command = new SqlCommand("spInsertarPrestamo", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@TipoMaterial", tipoMaterial);
                command.Parameters.AddWithValue("@Titulo", titulo);
                command.Parameters.AddWithValue("@Autor", autor);
                command.Parameters.AddWithValue("@TipoUsuario", tipoUsuario);
                command.Parameters.AddWithValue("@Fecha", fecha);
                command.Parameters.AddWithValue("@Hora", hora);
                command.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public DataTable ObtenerPrestamos()
        {
            using (SqlConnection connection = conexion.Conectar())
            {
                SqlCommand command = new SqlCommand("spObtenerPrestamos", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public int ContarLibrosPrestadosPorMes(int mes, int anio)
        {
            using (SqlConnection connection = conexion.Conectar())
            {
                SqlCommand command = new SqlCommand("spContarLibrosPrestadosPorMes", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Mes", mes);
                command.Parameters.AddWithValue("@Anio", anio);

                SqlParameter outputParam = new SqlParameter("@Cantidad", SqlDbType.Int) { Direction = ParameterDirection.Output };
                command.Parameters.Add(outputParam);

                connection.Open();
                command.ExecuteNonQuery();
                return (int)outputParam.Value;
            }
        }
    }
}
