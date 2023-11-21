using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRESENTACION
{
    public partial class ConsultaEncuesta : Form
    {
        GestorConsultaEncuesta gestor = new GestorConsultaEncuesta();
        public ConsultaEncuesta()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dateTimeInicio.Value;
            DateTime fechaFin = dateTimeFin.Value;
        }
    }
}
