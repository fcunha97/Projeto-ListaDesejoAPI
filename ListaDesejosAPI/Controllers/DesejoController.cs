using ListaDesejosAPI.Data;
using ListaDesejosAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace ListaDesejosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DesejoController : ControllerBase
    {

        private UsuarioContext _context;

        public DesejoController(UsuarioContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Authorize]
        public IActionResult AdicionaDesejo([FromBody] Desejo desejo)
        {

            var id = HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

            desejo.UsuarioId = Convert.ToInt32(id);

            _context.Desejos.Add(desejo);

            _context.SaveChanges();    
            
            return CreatedAtAction(nameof(RecuperaDesejoPorId), new { Id = desejo.Id }, desejo);
           
        }

     

        [HttpGet]
        [Authorize]
        public IActionResult RecuperaDesejoPorId()
        {
            var id = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value); 

            List<Desejo> desejos = _context.Desejos.Where(x => x.UsuarioId == id).ToList();
            if (desejos != null)
            {
                return Ok(desejos);
            }

            return NotFound();
        }


        [HttpPut("{id}")]
        [Authorize]

        public IActionResult AlteraDesejoPorid(int id, [FromBody] Desejo desejoNovo)
        {
            Desejo desejo = _context.Desejos.FirstOrDefault(desejo => desejo.Id == id);
            if (desejo == null)
            {
                return NotFound();
            }

            desejo.Descricao = desejoNovo.Descricao;          
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]

        public IActionResult DeletaDesejo(int id) {

            Desejo desejo = _context.Desejos.FirstOrDefault(desejo => desejo.Id == id);
            if (desejo == null)
            {
                return NotFound();
            }
                _context.Remove(desejo);
                _context.SaveChanges();
                return NoContent();
        }
    }
}