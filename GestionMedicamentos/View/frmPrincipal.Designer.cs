namespace GestionMedicamentos.View
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlPrincipal = new System.Windows.Forms.TabControl();
            this.tabClientes = new System.Windows.Forms.TabPage();
            this.tabProductos = new System.Windows.Forms.TabPage();
            this.tabFacturas = new System.Windows.Forms.TabPage();
            this.tabDetalleFactura = new System.Windows.Forms.TabPage();
            this.tabControlPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlPrincipal
            // 
            this.tabControlPrincipal.Controls.Add(this.tabClientes);
            this.tabControlPrincipal.Controls.Add(this.tabProductos);
            this.tabControlPrincipal.Controls.Add(this.tabFacturas);
            this.tabControlPrincipal.Controls.Add(this.tabDetalleFactura);
            this.tabControlPrincipal.Location = new System.Drawing.Point(25, 27);
            this.tabControlPrincipal.Name = "tabControlPrincipal";
            this.tabControlPrincipal.SelectedIndex = 0;
            this.tabControlPrincipal.Size = new System.Drawing.Size(871, 558);
            this.tabControlPrincipal.TabIndex = 0;
            this.tabControlPrincipal.SelectedIndexChanged += new System.EventHandler(this.tabControlPrincipal_SelectedIndexChanged);
            this.tabControlPrincipal.Click += new System.EventHandler(this.tabControlPrincipal_SelectedIndexChanged);
            // 
            // tabClientes
            // 
            this.tabClientes.Location = new System.Drawing.Point(4, 29);
            this.tabClientes.Name = "tabClientes";
            this.tabClientes.Padding = new System.Windows.Forms.Padding(3);
            this.tabClientes.Size = new System.Drawing.Size(863, 525);
            this.tabClientes.TabIndex = 0;
            this.tabClientes.Text = "Clientes";
            this.tabClientes.UseVisualStyleBackColor = true;
            // 
            // tabProductos
            // 
            this.tabProductos.Location = new System.Drawing.Point(4, 29);
            this.tabProductos.Name = "tabProductos";
            this.tabProductos.Padding = new System.Windows.Forms.Padding(3);
            this.tabProductos.Size = new System.Drawing.Size(768, 403);
            this.tabProductos.TabIndex = 1;
            this.tabProductos.Text = "Productos";
            this.tabProductos.UseVisualStyleBackColor = true;
            // 
            // tabFacturas
            // 
            this.tabFacturas.Location = new System.Drawing.Point(4, 29);
            this.tabFacturas.Name = "tabFacturas";
            this.tabFacturas.Padding = new System.Windows.Forms.Padding(3);
            this.tabFacturas.Size = new System.Drawing.Size(768, 403);
            this.tabFacturas.TabIndex = 2;
            this.tabFacturas.Text = "Facturas";
            this.tabFacturas.UseVisualStyleBackColor = true;
            // 
            // tabDetalleFactura
            // 
            this.tabDetalleFactura.Location = new System.Drawing.Point(4, 29);
            this.tabDetalleFactura.Name = "tabDetalleFactura";
            this.tabDetalleFactura.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetalleFactura.Size = new System.Drawing.Size(768, 403);
            this.tabDetalleFactura.TabIndex = 3;
            this.tabDetalleFactura.Text = "Detalle Factura";
            this.tabDetalleFactura.UseVisualStyleBackColor = true;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 609);
            this.Controls.Add(this.tabControlPrincipal);
            this.Name = "frmPrincipal";
            this.Text = "frmPrincipal";
            this.tabControlPrincipal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlPrincipal;
        private System.Windows.Forms.TabPage tabClientes;
        private System.Windows.Forms.TabPage tabProductos;
        private System.Windows.Forms.TabPage tabFacturas;
        private System.Windows.Forms.TabPage tabDetalleFactura;
    }
}