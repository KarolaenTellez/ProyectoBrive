using System;
using System.Collections.Generic;

namespace ACMEInventario.Models
{
    public partial class TipoMovimiento
    {
        public TipoMovimiento()
        {
            Productos = new HashSet<Producto>();
        }

        public int Id { get; set; }
        public string TipoMovimiento1 { get; set; } = null!;
        public DateTime Fecha { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
