using Microsoft.AspNetCore.Mvc;
using storeAPI.Data;
using storeAPI.Models;

namespace storeAPI.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class productosController:ControllerBase
    {
        [HttpGet("callProductos")]
        public async Task<ActionResult<List<Productos>>> callProductos()
        {
            try
            {
                var funcion = new productosData();
                var lista = await funcion.showProductos();

                if (lista.Count == 0)
                {
                    return NotFound("no se han encontrado productos en el sistema");
                }

                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener los productos: {ex}");

                return StatusCode(500, "Ocurrió un error al obtener los productos. Por favor, inténtelo nuevamente más tarde.");
            }

        }

        [HttpPost("createProductos")]
        public async Task<ActionResult> createProductos([FromBody] Productos parametros)
        {
            try
            {
                var funcion = new productosData();
                await funcion.insertProductos(parametros);
                return StatusCode(200, "Producto creado de forma exitosa");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el producto: {ex}");
                return StatusCode(500, "Ocurrió un error al crear el producto. Por favor, inténtelo nuevamente más tarde.");
            }
        }

        [HttpPut("updateProductos")]
        public async Task<ActionResult> updateProductos([FromBody] Productos parametros)
        {
            try
            {
                var funcion = new productosData();
                await funcion.editProductos(parametros);
                return StatusCode(200, "Producto actualizado de forma exitosa");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el producto: {ex}");
                return StatusCode(500, "Ocurrió un error al actualizar el producto. Por favor, inténtelo nuevamente más tarde.");
            }
        }

        [HttpDelete("deleteProductos")]
        public async Task<ActionResult> deleteProductos([FromBody] Productos parametros)
        {
            try
            {
                var funcion = new productosData();
                await funcion.removeProductos(parametros);
                return StatusCode(200, "Producto eliminado de forma exitosa");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el producto: {ex}");
                return StatusCode(500, "Ocurrió un error al eliminar el producto. Por favor, inténtelo nuevamente más tarde.");
            }
        }

        [HttpGet("callCategorias")]
        public async Task<ActionResult<List<Productos>>> callCategorias([FromBody] Productos parametros)
        {
            try
            {
                var funcion = new productosData();
                var lista = await funcion.showCategoria(parametros);

                if (lista.Count == 0)
                {
                    return NotFound("no se han encontrado productos para esa categoria");
                }

                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener los productos: {ex}");

                return StatusCode(500, "Ocurrió un error al obtener los productos. Por favor, inténtelo nuevamente más tarde.");
            }
        }
    }
}
