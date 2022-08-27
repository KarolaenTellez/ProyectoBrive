using System;
using System.Collections.Generic;

namespace ACMEInventario.Models
{
    public partial class Sucursal
    {
        public Sucursal()
        {
            Productos = new HashSet<Producto>();
        }

        public int Id { get; set; }
        public string NombreSucursal { get; set; } = null!;

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
