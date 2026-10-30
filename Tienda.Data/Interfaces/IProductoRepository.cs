using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Data.Models;

namespace Tienda.Data.Interfaces
{
    public interface IProductoRepository
    {
        List<Producto> ObtenerTodos();

        Producto ObtenerPorId(int Id);

        bool Agregar(Producto producto);

        bool Actualizar(Producto producto);

        bool Eliminar(int id);
    }
}
