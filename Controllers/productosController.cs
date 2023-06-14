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
            var funcion = new productosData();
            var lista = await funcion.showProductos();

            return lista;
        }

        [HttpPost("createProductos")]
        public async Task createProductos([FromBody] Productos parametros)
        {
            var funcion = new productosData();
            await funcion.insertProductos(parametros);
        }

        [HttpPut("updateProductos")]
        public async Task<ActionResult> updateProductos([FromBody] Productos parametros)
        {
            var funcion = new productosData();
            await funcion.editProductos(parametros);
            return NoContent();
        }
    }
}
