using ListaDesejosAPI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace ListaDesejosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutentificacaoController : ControllerBase
    {
       
        [HttpGet]
        [Authorize]

        public IActionResult Authenticate()
        {
            var aut = HttpContext.User.Identity as ClaimsIdentity;
            var usuario = aut.Name;
            return Ok(usuario);
        }
    }
}
