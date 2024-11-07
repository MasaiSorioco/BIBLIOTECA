using CAPA_NEGOCIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAPA_PRESENTACION
{
    public partial class Form1 : Form
    {
        private PrestamoNegocio prestamoNegocio = new PrestamoNegocio();
        public Form1()
        {
            InitializeComponent();
            CargarDatosEnDataGridView();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string tipoMaterial = GetSelectedTipoMaterial();
                string titulo = txtTitulo.Text;
                string autor = txtAutor.Text;
                string tipoUsuario = GetSelectedTipoUsuario();
                DateTime fecha = dateTimePickerFecha.Value;
                TimeSpan hora = dateTimePickerHora.Value.TimeOfDay;
                string nombreUsuario = txtNombreUsuario.Text;

                prestamoNegocio.GuardarPrestamo(tipoMaterial, titulo, autor, tipoUsuario, fecha, hora, nombreUsuario);
                MessageBox.Show("Préstamo guardado exitosamente.");

                CargarDatosEnDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el préstamo: " + ex.Message);
            }
        }
        private void CargarDatosEnDataGridView()
        {
            dataGridViewPrestamos.DataSource = prestamoNegocio.ObtenerTodosPrestamos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime selectedMonth = dateTimePickerFecha.Value;
            int mes = selectedMonth.Month;
            int anio = selectedMonth.Year;

            int cantidadLibros = prestamoNegocio.ObtenerNumeroLibrosPrestados(mes, anio);
            MessageBox.Show($"Número de libros prestados en el mes seleccionado: {cantidadLibros}");
        }
        private string GetSelectedTipoMaterial()
        {
            if (rbLibro.Checked) return "LIBRO";
            if (rbMonografia.Checked) return "MONOGRAFIA";
            if (rbTesis.Checked) return "TESIS";
            if (rbPeriodico.Checked) return "PERIODICO";
            return string.Empty;
        }

        private string GetSelectedTipoUsuario()
        {
            if (rbAlumno.Checked) return "ALUMNO";
            if (rbDocente.Checked) return "DOCENTE";
            if (rbAdministrativo.Checked) return "ADMINISTRATIVO";
            if (rbVisita.Checked) return "VISITA";
            return string.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

