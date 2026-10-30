using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.Data.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Precio { get; set; }
        public string Categoria { get; set; } = null!;
        public bool EstaActivo { get; set; }
    }
}
