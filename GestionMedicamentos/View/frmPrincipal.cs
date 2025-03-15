using System;
using System.Windows.Forms;

namespace GestionMedicamentos.View
{
    public partial class frmPrincipal : Form
    {
        private frmCliente formularioClientes;

        public frmPrincipal()
        {
            InitializeComponent();
            formularioClientes = new frmCliente(); 
            CargarFormulario(formularioClientes, tabClientes); 
        }

        private void tabControlPrincipal_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControlPrincipal.SelectedTab.Name)
            {
                case "tabClientes":

                    if (tabClientes.Controls.Count == 0)
                        CargarFormulario(new frmCliente(), tabClientes);
                    break;
                case "tabProductos":
                    if (tabProductos.Controls.Count == 0)
                        CargarFormulario(new frmProducto(), tabProductos);
                    break;
                case "tabFacturas":
                    if (tabFacturas.Controls.Count == 0)
                        CargarFormulario(new frmFactura(), tabFacturas);
                    break;
                case "tabDetalleFactura":
                    if (tabDetalleFactura.Controls.Count == 0)
                        CargarFormulario(new frmDetalleFactura(), tabDetalleFactura);
                    break;
            }
        }

        private void CargarFormulario(Form formulario, TabPage pestaña)
        {
            formulario.TopLevel = false;
            formulario.Dock = DockStyle.Fill;
            pestaña.Controls.Clear();
            pestaña.Controls.Add(formulario);
            formulario.Show();
        }
    }
}
