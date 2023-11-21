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
    public partial class Iniciar_Sesion : Form
    {
        public Iniciar_Sesion()
        {
            InitializeComponent();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            List<Usuario> ListaEstados = new CN_Usuario().Listar();
            mostrarEstados(ListaEstados);
        }

        public void mostrarEstados(List<Usuario> ListaEstados)
        {
            dataGridView1.DataSource = ListaEstados;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Usuario> ListaUsuarios = new CN_Usuario().Listar();
            foreach (Usuario usu in ListaUsuarios)
            {
                if (usu.nomusu == txtUsuario.Text && usu.clave == txtContrasena.Text)
                {
                    MessageBox.Show("¡Hola, mundo!", "Mensaje Informati", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }
    }
}
