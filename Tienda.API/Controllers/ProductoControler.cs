using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tienda.Services.DTOs;
using Tienda.Services.Interfaces;

namespace Tienda.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;

        // inyeccion de dependecias

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            var productos = _productoService.ObtenerTodos();
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            var producto = _productoService.ObtenerPorId(id);

            if(producto == null)
            {
                return NotFound(new { mensaje = $"No se encontro un producto con el ID {id}" });
            }

            return Ok(producto);
        }

        [HttpPost]
        public IActionResult Crear([FromBody] CreateProductoDto dto)
        {
            var nuevoProducto = _productoService.Crear(dto);

            return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevoProducto.Id }, nuevoProducto);
        }

        [HttpPut("{id}")]
        public IActionResult Actualizar(int id, [FromBody] CreateProductoDto dto)
        {
            var actualizado = _productoService.Actualizar(id, dto);

            if (!actualizado)
            {
                return NotFound(new { mensaje = $"No se puede Actualizar. El producto {id} no existe" });
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            var eliminado = _productoService.Eliminar(id);

            if(!eliminado)
            {
                return NotFound(new { mensaje = $"No se puede eliminar. El producto {id} no existe" });
            }
            return NoContent();
        }
    }
}
