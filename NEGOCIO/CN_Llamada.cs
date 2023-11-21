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
    }
}
