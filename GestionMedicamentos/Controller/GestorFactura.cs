using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using GestionMedicamentos.Model;

namespace GestionMedicamentos.Controller
{
    public class GestorFactura
    {
        private Conexion conexion = new Conexion();

        public List<Factura> ObtenerFacturas()
        {
            List<Factura> lista = new List<Factura>();
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM factura", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Factura()
                    {
                        IdFactura = (int)reader["id_factura"],
                        IdCliente = reader["id_cliente"].ToString(),
                        Fecha = (DateTime)reader["fecha"],
                        Total = (decimal)reader["total"]
                    });
                }
            }
            return lista;
        }

        public int InsertarFactura(Factura factura)
        {
            int nuevaFacturaId;
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO factura (id_cliente, total) OUTPUT INSERTED.id_factura VALUES (@id_cliente, @total)", conn);
                cmd.Parameters.AddWithValue("@id_cliente", factura.IdCliente);
                cmd.Parameters.AddWithValue("@total", factura.Total);
                nuevaFacturaId = (int)cmd.ExecuteScalar();
            }
            return nuevaFacturaId;
        }

        public void ActualizarFactura(Factura factura)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE factura SET id_cliente=@id_cliente, total=@total WHERE id_factura=@id", conn);
                cmd.Parameters.AddWithValue("@id", factura.IdFactura);
                cmd.Parameters.AddWithValue("@id_cliente", factura.IdCliente);
                cmd.Parameters.AddWithValue("@total", factura.Total);
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarFactura(int id)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM factura WHERE id_factura=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
