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
    public class CD_Encuesta
    {
        public List<Encuesta> Listar()
        {
            List<Encuesta> lista = new List<Encuesta>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "SELECT e.Descripcion FROM Encuesta e";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Encuesta()
                            {
                                descripcion = reader["Descripcion"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Encuesta>();
                }
            }
            return lista;
        }
            
    }
}
