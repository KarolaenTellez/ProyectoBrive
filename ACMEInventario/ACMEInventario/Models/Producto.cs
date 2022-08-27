using System;
using System.Collections.Generic;

namespace ACMEInventario.Models
{
    public partial class Producto
    {
        public int Id { get; set; }
        public int CodigoBarra { get; set; }
        public string Nombre { get; set; } = null!;
        public int Cantidad { get; set; }
        public int IdTipoMovimiento { get; set; }
        public int IdSucursal { get; set; }
        public decimal PrecioUnitario { get; set; }

        public virtual Sucursal IdSucursalNavigation { get; set; } = null!;
        public virtual TipoMovimiento IdTipoMovimientoNavigation { get; set; } = null!;
    }
}
