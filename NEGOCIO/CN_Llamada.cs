using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ENTIDADES;
using DATOS;
using System.Windows.Forms;

namespace NEGOCIO
{
    public class CN_Llamada
    {
        private CD_Llamada objcd_llamada = new CD_Llamada();

        public List<Llamada> Listar()
        {
            return objcd_llamada.Listar();
        }

        public CambioEstado determinarUltimoEstado(Llamada llamada)
        {
            List<CambioEstado> cambios = new List<CambioEstado>();
            cambios = new CN_CambioEstado().Listar(llamada.Idll);
            CambioEstado ultimo = new CambioEstado();

            foreach (CambioEstado cambioEstado in cambios)
            {
                /*
                bool var1 = new CN_CambioEstado().GetNombreEstado(cambioEstado);
         
                if (var1 == true)
                {
                    DateTime var2 = cambioEstado.fechaHoraInicio;
                    if (var2 >= fechainicio && var2 <= fechafin)
                    {
                        bool var3 = llamada.encuestaEnviada;
                        if (var3 == true)
                        {
                            return true;
                        }
                    }
                }*/
                if(ultimo == null)
                {
                    ultimo = cambioEstado;
                }
                else
                {
                    DateTime var1 = new CN_CambioEstado().GetFechaCambio(cambioEstado);
                    DateTime var2 = new CN_CambioEstado().GetFechaCambio(ultimo);
                    if(var1 > var2)
                    {
                        ultimo = cambioEstado;
                    }
                }
                
            }
          
            return ultimo;
        }

        public DateTime ObtenerFecha(List<CambioEstado> cambios)
        {
            DateTime primerFecha = new DateTime();
            bool Bandera = false;
            foreach (CambioEstado i in cambios)
            {
                if (Bandera == false)
                {
                    primerFecha = i.fechaHoraInicio;
                    Bandera = true;
                }
                else
                {
                    if (primerFecha > i.fechaHoraInicio)
                    {
                        primerFecha = i.fechaHoraInicio;
                    }
                }
            }
            return primerFecha;

        }
       
        public bool esDePeriodo(DateTime fechainicio, DateTime fechafin,Llamada llamada)
        {
            List<CambioEstado> cambios = new List<CambioEstado>();
            cambios = new CN_CambioEstado().Listar(llamada.Idll);
            DateTime fechaPrimero = ObtenerFecha(cambios);
            if (fechaPrimero >= fechainicio && fechaPrimero <= fechafin)
            {
                return true;
            }
            else
            {
                return false;
            }
         
        
            //CambioEstado ultimoCambio = determinarUltimoEstado(llamada);

          
        }

        public List<String> getDatos(Llamada llamada)
        {
            List<String> listaDeDatos = new List<String>();

            Cliente clientedeLlamada = new CN_Cliente().obtenerCliente(llamada);

            string cliente = clientedeLlamada.nombreCompleto;

            CambioEstado ultimoCambio = determinarUltimoEstado(llamada);
            Estado estadoActual = new CN_CambioEstado().obtenerEstado(ultimoCambio.IdCam);


            //Cliente cliente = cn_Cliente.obtenerCliente(llamada);
            //DateTime var1 = new CN_CambioEstado().GetFechaCambio(cambioEstado);

            //string clientedeLlamada = cliente.nombreCompleto;

            /*
            string clienteDeLlamada = this.cliente.getNombreCliente();
            bool estadoFinalLlamada = this.determinarUltimoEstado(llamada);
            string estadoStringLlamada = "Finalizada";
            if (estadoFinalLlamada == false)
            {
                estadoStringLlamada = "Inicializada sin Finalizar";
            }
            int duracionLlamada = this.getDuracion();
            listaDeDatos.Add(clienteDeLlamada);
            listaDeDatos.Add(estadoStringLlamada);
            listaDeDatos.Add(Convert.ToString(duracionLlamada));
            */
            listaDeDatos.Add(cliente);
            listaDeDatos.Add(estadoActual.nombre);
            string mensaje = string.Join(Environment.NewLine, listaDeDatos);
            MessageBox.Show(mensaje, "Mensaje Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return listaDeDatos;

        }
    }
}
