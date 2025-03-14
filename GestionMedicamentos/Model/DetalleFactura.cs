using System;

namespace GestionMedicamentos.Model
{
    public class DetalleFactura
    {
        public int IdFactura { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
    }
}
