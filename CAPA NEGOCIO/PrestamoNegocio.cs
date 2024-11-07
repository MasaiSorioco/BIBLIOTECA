using CAPA_DATOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_NEGOCIO
{
    public class PrestamoNegocio
    {
        private PrestamoDatos prestamoDatos = new PrestamoDatos();

        public void GuardarPrestamo(string tipoMaterial, string titulo, string autor, string tipoUsuario, DateTime fecha, TimeSpan hora, string nombreUsuario)
        {
            prestamoDatos.InsertarPrestamo(tipoMaterial, titulo, autor, tipoUsuario, fecha, hora, nombreUsuario);
        }

        public DataTable ObtenerTodosPrestamos()
        {
            return prestamoDatos.ObtenerPrestamos();
        }

        public int ObtenerNumeroLibrosPrestados(int mes, int anio)
        {
            return prestamoDatos.ContarLibrosPrestadosPorMes(mes, anio);
        }
    }
}
