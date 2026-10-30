using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Services.Interfaces;
using Tienda.Data.Interfaces;
using Tienda.Services.DTOs;
using System.Reflection.Metadata.Ecma335;
using Tienda.Data.Models;


namespace Tienda.Services.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repository;

        // inyeccion de dependecias del repositorio de datos
        public ProductoService(IProductoRepository repository)
        {
            _repository = repository;
        }


        public List<ProductoDto> ObtenerTodos()
        {

            var productos = _repository.ObtenerTodos();
            var ListaDtos = new List<ProductoDto>();

            foreach (var p in productos)
            {
                ListaDtos.Add(new ProductoDto
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Precio = p.Precio,
                    Categoria = p.Categoria,
                    EstaActivo = p.EstaActivo

                });


            }

            return ListaDtos;

        }

        public ProductoDto ObtenerPorId(int id)
        {
            var producto = _repository.ObtenerPorId(id);
            if (producto == null) return null;

            return new ProductoDto
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Categoria = producto.Categoria,
                EstaActivo = producto.EstaActivo
            };
        }

        public ProductoDto Crear (CreateProductoDto dto)
        {
            var nuevo = new Producto
            {
                Nombre = dto.Nombre,
                Precio = dto.Precio,
                Categoria = dto.Categoria,
                EstaActivo = true
            };

            _repository.Agregar(nuevo);

            return new ProductoDto
            {
                Id = nuevo.Id,
                Nombre = nuevo.Nombre,
                Precio = nuevo.Precio,
                Categoria = nuevo.Categoria,
                EstaActivo = nuevo.EstaActivo
            };

        }

        public bool Actualizar (int id, CreateProductoDto dto)
        {
            var p = new Producto
            {
                Id = id,
                Nombre = dto.Nombre,
                Precio = dto.Precio,
                Categoria = dto.Categoria,
                EstaActivo = true
            };

            return _repository.Actualizar(p);
        }

        public bool Eliminar(int id)
        {
            return _repository.Eliminar(id);
        }
    }
}
