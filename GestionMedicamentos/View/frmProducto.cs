using System;
using System.Windows.Forms;
using GestionMedicamentos.Controller;
using GestionMedicamentos.Model;

namespace GestionMedicamentos.View
{
    public partial class frmProducto : Form
    {
        private GestorProducto gestor = new GestorProducto();

        public frmProducto()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            dgvProductos.DataSource = gestor.ObtenerProductos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Producto nuevo = new Producto()
            {
                Nombre = txtNombre.Text,
                Precio = decimal.Parse(txtPrecio.Text),
                Stock = int.Parse(txtStock.Text)
            };
            gestor.InsertarProducto(nuevo);
            btnCargar_Click(null, null);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Producto actualizar = new Producto()
            {
                IdProducto = int.Parse(txtId.Text),
                Nombre = txtNombre.Text,
                Precio = decimal.Parse(txtPrecio.Text),
                Stock = int.Parse(txtStock.Text)
            };
            gestor.ActualizarProducto(actualizar);
            btnCargar_Click(null, null);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            gestor.EliminarProducto(int.Parse(txtId.Text));
            btnCargar_Click(null, null);
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {

        }
    }
}
