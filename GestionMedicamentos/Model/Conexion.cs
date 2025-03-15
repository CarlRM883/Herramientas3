using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GestionMedicamentos.Model
{
    public class Conexion
    {
        private static string cadenaConexion = "Server=DESKTOP-BPTN76D\\SQLEXPRESS;Database=medicamentos;Trusted_Connection=True;";

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }

      
        public void ProbarConexion()
        {
            try
            {
                using (SqlConnection conn = ObtenerConexion())
                {
                    conn.Open();
                    MessageBox.Show("¡Conexión exitosa a la base de datos!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar a la base de datos:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
