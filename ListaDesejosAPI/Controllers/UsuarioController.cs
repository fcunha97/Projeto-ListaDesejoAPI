using ListaDesejosAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ListaDesejosAPI.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private UsuarioContext _context;
     
        public UsuarioController(UsuarioContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionaUsurario([FromBody] Usuario usuario) {
           
                     
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaUsuarioPorId), new { Id = usuario.Id }, usuario);
        }

        [HttpGet]
        public IActionResult RecuperaUsuario()
        {
            return Ok(_context.Usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaUsuarioPorId(int id)
        {
            Usuario usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.Id == id);
            if (usuario != null)
            {
                return Ok(usuario);
            }

            return NotFound();
        }
        
    }
}
