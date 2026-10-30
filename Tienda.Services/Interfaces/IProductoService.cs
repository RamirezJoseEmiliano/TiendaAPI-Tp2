using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Services.DTOs;

namespace Tienda.Services.Interfaces
{
    public interface IProductoService
    {
        List<ProductoDto> ObtenerTodos();
        ProductoDto ObtenerPorId(int id);
        ProductoDto Crear(CreateProductoDto dto);
        bool Actualizar(int id, CreateProductoDto dto);
        bool Eliminar(int id);
    }
}
