using Microsoft.AspNetCore.Mvc;
using storeAPI.Data;
using storeAPI.Models;

namespace storeAPI.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class productosController
    {
        [HttpGet]
        public async Task<ActionResult<List<Productos>>> callProductos()
        {
            var funcion = new productosData();
            var lista = await funcion.showProductos();
            return lista;
        }
    }
}
