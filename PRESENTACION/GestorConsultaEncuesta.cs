using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ENTIDADES;
using NEGOCIO;

namespace PRESENTACION
{
    public class GestorConsultaEncuesta
    {

		public List<Llamada> buscarLlamadasEncuestasRespondidas(DateTime fechainicio, DateTime fechafin)
		{
			List<Llamada> llamadasConEncuesta = new List<Llamada>();
			List<Llamada> llamadasDelGestor = new CN_Llamada().Listar();
			foreach (Llamada llamada in llamadasDelGestor)
			{
				bool var5 =  new CN_Llamada().esDePeriodo(fechainicio, fechafin,llamada);
				if (var5 == true)
				{
					llamadasConEncuesta.Add(llamada);
				}

			}
			return llamadasConEncuesta;
		}



		public List<Llamada> validarPeriodo(DateTime fechainicio, DateTime fechafin)
		{
			List<Llamada> llamadaCEncuesta = new List<Llamada>();
			if (fechainicio <= fechafin)
			{

				MessageBox.Show("¡Es fecha valida!", "Mensaje Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				llamadaCEncuesta = buscarLlamadasEncuestasRespondidas(fechainicio, fechafin);
				return llamadaCEncuesta;

			}
			else
			{
				MessageBox.Show("¡ERROR,No Es fecha valida!", "Mensaje Informativo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return llamadaCEncuesta;

			}
		}
		
	}
}
