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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            List<Estado> ListaEstados = new CN_Estado().Listar();
            mostrarEstados(ListaEstados);
        }

        public void mostrarEstados(List<Estado> ListaEstados)
        {
            dataGridView1.DataSource = ListaEstados;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
