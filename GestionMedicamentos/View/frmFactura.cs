using System;
using System.Windows.Forms;
using GestionMedicamentos.Controller;
using GestionMedicamentos.Model;

namespace GestionMedicamentos.View
{
    public partial class frmFactura : Form
    {
        private GestorFactura gestor = new GestorFactura();

        public frmFactura()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            dgvFacturas.DataSource = gestor.ObtenerFacturas();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Factura nueva = new Factura()
            {
                IdCliente = txtIdCliente.Text,
                Total = decimal.Parse(txtTotal.Text),
                Fecha = DateTime.Now
            };
            int nuevaFacturaId = gestor.InsertarFactura(nueva);
            txtIdFactura.Text = nuevaFacturaId.ToString();
            btnCargar_Click(null, null);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Factura actualizar = new Factura()
            {
                IdFactura = int.Parse(txtIdFactura.Text),
                IdCliente = txtIdCliente.Text,
                Total = decimal.Parse(txtTotal.Text)
            };
            gestor.ActualizarFactura(actualizar);
            btnCargar_Click(null, null);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            gestor.EliminarFactura(int.Parse(txtIdFactura.Text));
            btnCargar_Click(null, null);
        }
    }
}
