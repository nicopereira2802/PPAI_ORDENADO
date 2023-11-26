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
            dataGridLlamadas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
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
            dataGridLlamadas.ClearSelection();
            dataGridLlamadas.SelectionChanged += dataGridLlamadas_SelectionChanged;
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
        private void dataGridLlamadas_SelectionChanged(object sender, EventArgs e)
        {
            // Acciones que se ejecutarán cuando cambie la selección de filas
            // Puedes acceder a la fila seleccionada usando: dataGridLlamadas.SelectedRows[0]
            // Por ejemplo, puedes obtener el valor de una celda así: dataGridLlamadas.SelectedRows[0].Cells["descripcionOperador"].Value
            // Realiza aquí las acciones que necesites al seleccionar una fila.
            DataGridViewRow selectedRow = dataGridLlamadas.CurrentRow;

            // Verificar si se ha seleccionado una fila
            if (selectedRow != null)
            {
                // Obtener los valores de las celdas de la fila seleccionada
                Llamada llamadaSeleccionado = (Llamada)selectedRow.DataBoundItem;

                // Realizar cualquier otra acción que necesites con el objeto seleccionado
                // ...
                // Ejemplo de mostrar una propiedad del objeto en un MessageBox
                MessageBox.Show($"Se ha seleccionado el objeto: Propiedad1={llamadaSeleccionado.descripcionOperador}");
                //List<string> listaLlamadaDatos = gestorConsultarEncuesta.tomarSeleccionLlamada(llamadaSeleccionado);
                //mostrarDatosLLamada(listaLlamadaDatos);
            }
        }
    }
}
