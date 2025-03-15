using System.Collections.Generic;
using System.Data.SqlClient;
using GestionMedicamentos.Model;

namespace GestionMedicamentos.Controller
{
    public class GestorDetalleFactura
    {
        private Conexion conexion = new Conexion();

        public List<DetalleFactura> ObtenerDetallesFactura(int idFactura)
        {
            List<DetalleFactura> lista = new List<DetalleFactura>();
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM detallefactura WHERE id_factura=@id", conn);
                cmd.Parameters.AddWithValue("@id", idFactura);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new DetalleFactura()
                    {
                        IdFactura = (int)reader["id_factura"],
                        IdProducto = (int)reader["id_producto"],
                        Cantidad = (int)reader["cantidad"],
                        Subtotal = (decimal)reader["subtotal"]
                    });
                }
            }
            return lista;
        }

        public void InsertarDetalleFactura(DetalleFactura detalle)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO detallefactura (id_factura, id_producto, cantidad, subtotal) VALUES (@id_factura, @id_producto, @cantidad, @subtotal)", conn);
                cmd.Parameters.AddWithValue("@id_factura", detalle.IdFactura);
                cmd.Parameters.AddWithValue("@id_producto", detalle.IdProducto);
                cmd.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                cmd.Parameters.AddWithValue("@subtotal", detalle.Subtotal);
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarDetalleFactura(int idFactura, int idProducto)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM detallefactura WHERE id_factura=@id_factura AND id_producto=@id_producto", conn);
                cmd.Parameters.AddWithValue("@id_factura", idFactura);
                cmd.Parameters.AddWithValue("@id_producto", idProducto);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
