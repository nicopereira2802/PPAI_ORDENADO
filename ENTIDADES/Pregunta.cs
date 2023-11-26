using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Pregunta

    {
        public int idp { get; set; }
        public string pregunta { get; set; }
        public List<RespuestaPosible> respuesta { get; set; }

    }
}
