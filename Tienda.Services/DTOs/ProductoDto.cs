using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.Services.DTOs
{
    public class ProductoDto
    {
        // representa los datos que devuelve la API hacia afuera
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Precio { get; set; }
        public string Categoria { get; set; } = null!;
        public bool EstaActivo { get; set; }
    }
}
