using System;
using System.Windows.Forms;
using GestionMedicamentos.Controller;
using GestionMedicamentos.Model;

namespace GestionMedicamentos.View
{
    public partial class frmDetalleFactura : Form
    {
        private GestorDetalleFactura gestor = new GestorDetalleFactura();

        public frmDetalleFactura()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdFactura.Text))
            {
                MessageBox.Show("Ingrese un ID de factura válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtIdFactura.Text, out int idFactura))
            {
                MessageBox.Show("El ID de factura debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

       
            dgvDetallesFactura.DataSource = gestor.ObtenerDetallesFactura(idFactura);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DetalleFactura nuevo = new DetalleFactura()
            {
                IdFactura = int.Parse(txtIdFactura.Text),
                IdProducto = int.Parse(txtIdProducto.Text),
                Cantidad = int.Parse(txtCantidad.Text),
                Subtotal = decimal.Parse(txtSubtotal.Text)
            };
            gestor.InsertarDetalleFactura(nuevo);
            btnCargar_Click(null, null);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            gestor.EliminarDetalleFactura(int.Parse(txtIdFactura.Text), int.Parse(txtIdProducto.Text));
            btnCargar_Click(null, null);
        }
    }
}
