using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Tienda.Data.Interfaces;
using Tienda.Data.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tienda.Data.Repositories
{
    public class ProductoRepository : IProductoRepository
    {


        private readonly List<Producto> _productos;

        // constructor
        public ProductoRepository()
        {
            _productos = new List<Producto>
            {
                new Producto { Id = 1, Nombre = "Camiseta", Precio = 19.99m, Categoria = "Ropa", EstaActivo = true },
                new Producto { Id = 2, Nombre = "Pantalón", Precio = 39.99m, Categoria = "Ropa", EstaActivo = true },
                new Producto { Id = 3, Nombre = "Zapatos", Precio = 59.99m, Categoria = "Calzado", EstaActivo = true }
            };
        }




        public bool Actualizar(Producto producto)
        {
            var pExistente = ObtenerPorId(producto.Id);
            if(pExistente != null)
            {
                pExistente.Nombre = producto.Nombre;
                pExistente.Precio = producto.Precio;
                pExistente.Categoria = producto.Categoria;
                pExistente.EstaActivo = producto.EstaActivo;

                return true;
            }
            else 
            {
                return false;
            }
            
        }

        public bool Agregar(Producto producto)
        {
            if (producto == null)
            {
                return false;
            }

            producto.Id = _productos.Count > 0 ? _productos.Max(p => p.Id) + 1 : 1;
            _productos.Add(producto);
            return true;
        }

        public bool Eliminar(int id)
        {
            var pExistente = ObtenerPorId(id);
            if (pExistente != null)
            {
                pExistente.EstaActivo = false;

                return true;
            }
            else
            {
                return false;
            }
        }

        public Producto ObtenerPorId(int id)
        {
            return _productos.FirstOrDefault(p => p.Id == id && p.EstaActivo);
        }

        public List<Producto> ObtenerTodos()
        {
            return _productos.Where(p => p.EstaActivo).ToList();
        }
    }
}
