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

        public CambioEstado determinarUltimoEstado(DateTime fechainicio, DateTime fechafin,Llamada llamada)
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
          
            return false;
        }

        private object CN_CambioEstado()
        {
            throw new NotImplementedException();
        }

        public bool esDePeriodo(DateTime fechainicio, DateTime fechafin,Llamada llamada)
        {
            
            bool var4 = determinarUltimoEstado(fechainicio, fechafin, llamada);
            if (var4 == true)
            {
                return true;
            }
            return false;
        }
    }
}
