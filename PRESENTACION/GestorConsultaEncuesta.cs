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
					if (llamada.encuestaEnviada == true)
					{
						llamadasConEncuesta.Add(llamada);
					}
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

		public List<string> buscarDatosLlamada(Llamada llamadaSeleccionada)
		{
			List<string> listaTotal = new List<String>();
			List<string> lista1 = new List<String>();
			List<string> lista2 = new List<String>();

			lista1 = new CN_Llamada().getDatos(llamadaSeleccionada);
			/*
			lista1 = llamadaSeleccionada.getDatos(llamadaSeleccionada);
			lista2 = llamadaSeleccionada.getRespuestas(llamadaSeleccionada);
			listaTotal = lista1.Concat(lista2).ToList();
			this.ListaPreguntas = lista2;
			this.ListaEncabezado = lista1;
			this.ListaFinalDeDatos = listaTotal;
			*/

			return listaTotal;
		}
		public List<string> tomarSeleccionLlamada(Llamada llamadaSeleccionada)
		{
			List<string> listaTotal2 = new List<string>();
			listaTotal2 = buscarDatosLlamada(llamadaSeleccionada);
			return listaTotal2;
			//listaTotal2 = buscarDatosLlamada(llamadaSeleccionada);

		}


	}
}
