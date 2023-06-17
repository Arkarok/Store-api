using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using storeAPI.Models;

namespace storeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usuarioController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> autenticate([FromBody] Usuarios parametros)
        {
            return Ok("por el momento nada");
        }
    }
}
