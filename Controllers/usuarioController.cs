using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using storeAPI.Data;
using storeAPI.Models;

namespace storeAPI.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class usuarioController : ControllerBase
    {
        [HttpPost("autenticate")]
        public async Task<ActionResult<bool>> autenticate([FromBody] Usuarios parametros)
        {
            var funcion = new usuarioData();
            var autenticacion = await funcion.autentication(parametros);

            if (autenticacion)
            {
                return Ok("usuario autenticado exitosamente");
            }
            else
            {
                return BadRequest("usuario autenticado incorrectamente");
            }
        }
    }
}
