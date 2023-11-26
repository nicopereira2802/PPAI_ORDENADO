using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using ENTIDADES;

namespace DATOS
{
    public class CD_CambioEstado
    {
        
        public List<CambioEstado> Listar()
        {
            List<CambioEstado> lista = new List<CambioEstado>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("SELECT c.FechaHoraInicio,e.Id FROM CambioEstado c");
                    query.AppendLine("INNER JOIN Estado e ON c.IdEstado = e.Id");
                    
                    //string query = "select DescripcionOperador,DetalleEncuesta,Duracion,EncuestaEnviada from Llamada";

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            lista.Add(new CambioEstado()
                            {
                                fechaHoraInicio = DateTime.Parse(reader["FechaHoraInicio"].ToString()),
                            
                                estado = new Estado() {  nombre = reader["Id"].ToString() }

                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<CambioEstado>();
                }
            }
            return lista;
        }
        
    }
}
