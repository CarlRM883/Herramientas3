using System.Collections.Generic;
using System.Data.SqlClient;
using GestionMedicamentos.Model;

namespace GestionMedicamentos.Controller
{
    public class GestorProducto
    {
        private Conexion conexion = new Conexion();

        public List<Producto> ObtenerProductos()
        {
            List<Producto> lista = new List<Producto>();
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM producto", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Producto()
                    {
                        IdProducto = (int)reader["id_producto"],
                        Nombre = reader["nombre"].ToString(),
                        Precio = (decimal)reader["precio"],
                        Stock = (int)reader["stock"]
                    });
                }
            }
            return lista;
        }

        public void InsertarProducto(Producto producto)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO producto (nombre, precio, stock) VALUES (@nombre, @precio, @stock)", conn);
                cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@precio", producto.Precio);
                cmd.Parameters.AddWithValue("@stock", producto.Stock);
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarProducto(Producto producto)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE producto SET nombre=@nombre, precio=@precio, stock=@stock WHERE id_producto=@id", conn);
                cmd.Parameters.AddWithValue("@id", producto.IdProducto);
                cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@precio", producto.Precio);
                cmd.Parameters.AddWithValue("@stock", producto.Stock);
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarProducto(int id)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM producto WHERE id_producto=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
