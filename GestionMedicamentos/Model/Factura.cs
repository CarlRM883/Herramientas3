using System;
using System.Collections.Generic;

namespace GestionMedicamentos.Model
{
    public class Factura
    {
        public int IdFactura { get; set; }
        public string IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public List<DetalleFactura> Detalles { get; set; }
    }
}
