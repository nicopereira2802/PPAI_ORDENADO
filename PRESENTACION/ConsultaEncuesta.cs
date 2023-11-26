using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ENTIDADES;
using NEGOCIO;


namespace PRESENTACION
{
    public partial class ConsultaEncuesta : Form
    {
        GestorConsultaEncuesta gestor = new GestorConsultaEncuesta();
        public ConsultaEncuesta()
        {
            InitializeComponent();
            dataGridLlamadas.CellFormatting += dataGridLlamadas_CellFormatting;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dateTimeInicio.Value;
            DateTime fechaFin = dateTimeFin.Value;
            List<Llamada> llamadasEPantalla = gestor.validarPeriodo(fechaInicio, fechaFin);
            //List<Llamada> llamadasEPantalla = new CN_Llamada().Listar();
            mostrarLlamadas(llamadasEPantalla);

        }

        public void mostrarLlamadas(List<Llamada> llamadasCEncuesta)
        {
            // Columna para la propiedad Nombre de ClasePrincipal
            // Columna para el atributo de OtraClase
            dataGridLlamadas.DataSource = llamadasCEncuesta;
            dataGridLlamadas.Columns["descripcionOperador"].HeaderText = "Descripción del Operador";
            dataGridLlamadas.Columns["detalleEncuesta"].HeaderText = "Detalle de la Encuesta";
            dataGridLlamadas.Columns["duracion"].HeaderText = "Duración";
            dataGridLlamadas.Columns["encuestaEnviada"].HeaderText = "Encuesta Enviada";
            dataGridLlamadas.Columns["cliente"].HeaderText = "Cliente";
        }

        private void dataGridLlamadas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verifica si la celda que se está formateando es la que te interesa
            if (e.ColumnIndex == dataGridLlamadas.Columns["cliente"].Index && e.RowIndex >= 0)
            {

                Cliente cliente = (Cliente)e.Value;

                int dni = cliente.dni;

                e.Value = dni.ToString();

                e.FormattingApplied = true;
            }
        }
    }
}
