using ListaDesejosAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using ListaDesejosAPI.Services;
using ListaDesejosAPI.Models;
using Xunit;
using System.Linq;

namespace ListaDesejosAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private UsuarioContext _context;

        public LoginController(UsuarioContext context)
        {
            _context = context;
        }
        [HttpPost]

        public IActionResult Authenticate([FromBody] Usuario model)
        {
            Usuario usuario = _context.Usuarios.FirstOrDefault(u => u.Login == model.Login && u.Senha == model.Senha);
            if (usuario == null)
                return NotFound("Usuário ou senha inválidos");


            var token = TokenService.GenerateToken(usuario);

            return Ok(token);
           

        }
    }
}
