using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ENTIDADES;
using System.Net;

namespace DATOS
{
    public class CD_Cliente
    {
        public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "select Dni,NroCelular,NombreCompleto from Cliente";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Cliente()
                            {
                                dni = int.Parse(reader["Dni"].ToString()),
                                nroCelular = reader["NroCelular"].ToString(),
                                nombreCompleto = reader["NombreCompleto"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Cliente>();
                }
            }
            return lista;
        }

        public Cliente obtenerClienteLlamada(int dni)
        {
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "SELECT Dni, NroCelular, NombreCompleto FROM Cliente WHERE Dni = @Dni";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@Dni", dni);

                    oconexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Cliente()
                            {
                                dni = int.Parse(reader["Dni"].ToString()),
                                nroCelular = reader["NroCelular"].ToString(),
                                nombreCompleto = reader["NombreCompleto"].ToString()
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de errores...
                }
            }
            return null; // Cliente no encontrado
        }


    }

}
