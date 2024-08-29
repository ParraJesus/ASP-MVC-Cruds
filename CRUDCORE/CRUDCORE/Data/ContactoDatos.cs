using CRUDCORE.Models;
using MySql.Data.MySqlClient;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CRUDCORE.Data
{
    public class ContactoDatos
    {
        public List<ContactoModelo> Listar() 
        {
            var oLista = new List<ContactoModelo>();
            var cn = new Conexion();

            using(var conexion = new MySqlConnection(cn.GetCadenaSQL())) 
            {
                conexion.Open();

                using (var cmd = new MySqlCommand("sp_Listar", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            oLista.Add(new ContactoModelo()
                            {
                                IdContacto = Convert.ToInt32(reader["IdContacto"]),
                                Nombre = reader["Nombre"].ToString(),
                                Telefono = reader["Telefono"].ToString(),
                                Correo = reader["Correo"].ToString()
                            });
                        }
                    }
                }
            }

            return oLista;
        }

        public ContactoModelo Obtener(int IdContacto)
        {
            var oContacto = new ContactoModelo();
            var cn = new Conexion();

            using (var conexion = new MySqlConnection(cn.GetCadenaSQL()))
            {
                conexion.Open();

                using (MySqlCommand cmd = new MySqlCommand("sp_Obtener", conexion))
                {

                    cmd.Parameters.AddWithValue("IdContacto", IdContacto);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            new ContactoModelo()
                            {
                                IdContacto = Convert.ToInt32(reader["IdContacto"]),
                                Nombre = reader["Nombre"].ToString(),
                                Telefono = reader["Telefono"].ToString(),
                                Correo = reader["Correo"].ToString()
                            };
                        }
                    }
                }
            }

            return oContacto;
        }

        public bool Guardar(ContactoModelo oContacto) 
        {
            bool answer;

            try 
            {
                var cn = new Conexion();

                using (var conexion = new MySqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    using (MySqlCommand cmd = new MySqlCommand("sp_Guardar", conexion)) // Asocia la conexión al comando
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("Nombre", oContacto.Nombre);
                        cmd.Parameters.AddWithValue("Telefono", oContacto.Telefono);
                        cmd.Parameters.AddWithValue("Correo", oContacto.Correo);
                        cmd.ExecuteNonQuery();
                    }
                }
                answer = true;
            }
            catch (Exception e)
            {
                string errorMessage = e.Message;
                answer = false;
            }

            return answer;
        }

        public bool Editar(ContactoModelo oContacto)
        {
            bool answer;

            try
            {
                var cn = new Conexion();

                using (var conexion = new MySqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_Editar");
                    cmd.Parameters.AddWithValue("IdContacto", oContacto.IdContacto);
                    cmd.Parameters.AddWithValue("Nombre", oContacto.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", oContacto.Telefono);
                    cmd.Parameters.AddWithValue("Correo", oContacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                answer = true;
            }
            catch (Exception e)
            {
                string errorMessage = e.Message;
                answer = false;
            }

            return answer;
        }

        public bool Eliminar(int IdContacto)
        {
            bool answer;

            try
            {
                var cn = new Conexion();

                using (var conexion = new MySqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_Eliminar");
                    cmd.Parameters.AddWithValue("IdContacto", IdContacto);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                answer = true;
            }
            catch (Exception e)
            {
                string errorMessage = e.Message;
                answer = false;
            }

            return answer;
        }
    }
}
