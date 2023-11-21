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
    public class CD_Llamada
    {
        public List<Llamada> Listar()
        {
            List<Llamada> lista = new List<Llamada>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "select DescripcionOperador,DetalleEncuesta,Duracion from Llamada";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                           // Cliente clienteA = new Cliente(); // Aquí debes inicializar un objeto Cliente
                           // clienteA.dni = reader.GetInt32(reader.GetOrdinal("Duracion")); // Ajusta esto según la propiedad en tu clase Cliente
                             lista.Add(new Llamada()
                            {

                                descripcionOperador = reader["DescripcionOperador"].ToString(),
                                detalleEncuesta = reader["DetalleEncuesta"].ToString(),
                                duracion = reader.GetInt32(reader.GetOrdinal("Duracion")),
                                //encuestaEnviada = reader.GetBoolean(reader.GetOrdinal("EncuestaEnviada")),
                                //cliente = clienteA

                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Llamada>();
                }
            }
            return lista;
        }
    }
}
