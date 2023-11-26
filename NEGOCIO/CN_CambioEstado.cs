using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using DATOS;

namespace NEGOCIO
{
    public class CN_CambioEstado
    {
        private CD_CambioEstado objcd_cambioestado = new CD_CambioEstado();

        public List<CambioEstado> Listar()
        {
            return objcd_cambioestado.Listar();
        }
    }
}
