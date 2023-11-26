using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ENTIDADES;
using DATOS;

namespace NEGOCIO
{
    public class CN_Llamada
    {
        private CD_Llamada objcd_llamada = new CD_Llamada();

        public List<Llamada> Listar()
        {
            return objcd_llamada.Listar();
        }

        public bool determinarEstadoInicial(DateTime fechainicio, DateTime fechafin,Llamada llamada)
        {
            
           
            foreach (CambioEstado cambioEstado in llamada.cambiosEstados)
            {
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
                }
            }
           
            return false;
        }

        public bool esDePeriodo(DateTime fechainicio, DateTime fechafin,Llamada llamada)
        {
            bool var4 = this.determinarEstadoInicial(fechainicio, fechafin, llamada);
            if (var4 == true)
            {
                return true;
            }
            return false;
        }
    }
}
