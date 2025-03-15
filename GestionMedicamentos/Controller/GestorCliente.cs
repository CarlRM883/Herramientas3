using System.Collections.Generic;
using System.Data.SqlClient;
using GestionMedicamentos.Model;

namespace GestionMedicamentos.Controller
{
    public class GestorCliente
    {
        private Conexion conexion = new Conexion();

        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> lista = new List<Cliente>();
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM cliente", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Cliente()
                    {
                        Id = reader["id_cliente"].ToString(),
                        Nombre = reader["nombre"].ToString(),
                        Correo = reader["correo"].ToString(),
                        Telefono = reader["telefono"].ToString()
                    });
                }
            }
            return lista;
        }


        public void InsertarCliente(Cliente cliente)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO cliente (id_cliente, nombre, correo, telefono) VALUES (@id, @nombre, @correo, @telefono)", conn);
                cmd.Parameters.AddWithValue("@id", cliente.Id);
                cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@correo", cliente.Correo);
                cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarCliente(Cliente cliente)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE cliente SET nombre=@nombre, correo=@correo, telefono=@telefono WHERE id_cliente=@id", conn);
                cmd.Parameters.AddWithValue("@id", cliente.Id);
                cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@correo", cliente.Correo);
                cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarCliente(string id)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM cliente WHERE id_cliente=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
