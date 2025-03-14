using System;
using System.Windows.Forms;
using GestionMedicamentos.Controller;
using GestionMedicamentos.Model;

namespace GestionMedicamentos.View
{
    public partial class frmCliente : Form
    {
        private GestorCliente gestor = new GestorCliente();

        public frmCliente()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            GestorCliente gestor = new GestorCliente();
            dgvClientes.DataSource = gestor.ObtenerClientes();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Cliente nuevo = new Cliente()
            {
                Id = txtId.Text,
                Nombre = txtNombre.Text,
                Correo = txtCorreo.Text,
                Telefono = txtTelefono.Text
            };
            gestor.InsertarCliente(nuevo);
            btnCargar_Click(null, null);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Cliente actualizar = new Cliente()
            {
                Id = txtId.Text,
                Nombre = txtNombre.Text,
                Correo = txtCorreo.Text,
                Telefono = txtTelefono.Text
            };
            gestor.ActualizarCliente(actualizar);
            btnCargar_Click(null, null);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            gestor.EliminarCliente(txtId.Text);
            btnCargar_Click(null, null);
        }
        private void btnProbarConexion_Click(object sender, EventArgs e)
        {
            Conexion conexion = new Conexion();
            conexion.ProbarConexion();
        }

    }
}
