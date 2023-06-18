using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using storeAPI.Data;
using storeAPI.Models;

namespace storeAPI.Controllers
{
    [Route("api/pedidos")]
    [ApiController]
    public class pedidoController : ControllerBase
    {
        [HttpPost("createPedidos")]
        public async Task createPedidos([FromBody] Pedidos parametros)
        {
            var funcion = new pedidoData();
            await funcion.insertPedidos(parametros);
        }
    }
}
