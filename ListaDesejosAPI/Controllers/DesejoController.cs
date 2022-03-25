using ListaDesejosAPI.Data;
using ListaDesejosAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            
            _context.Desejos.Add(desejo);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaDesejoPorId), new { Id = desejo.Id }, desejo);
           
        }

        [HttpGet]
        public IActionResult RecuperaDesejo()
        {
            return Ok(_context.Desejos);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaDesejoPorId(int id)
        {
            Desejo desejo = _context.Desejos.FirstOrDefault(desejo => desejo.Id == id);
            if (desejo != null)
            {
                return Ok(desejo);
            }

            return NotFound();
        }


        [HttpPut("{id}")]

        public IActionResult AlteraDesejoPorid(int id, [FromBody] Desejo desejoNovo)
        {
            Desejo desejo = _context.Desejos.FirstOrDefault(desejo => desejo.Id == id);
            if (desejo == null)
            {
                return NotFound();
            }

            desejo.Descricao = desejoNovo.Descricao;          
            _context.SaveChanges();
            return NotFound();
        }

        [HttpDelete("{id}")]

        public IActionResult DeletaDesejo(int id) {

            Desejo desejo = _context.Desejos.FirstOrDefault(desejo => desejo.Id == id);
            if (desejo == null)
            {
                return NotFound();
            }
                _context.Remove(desejo);
                _context.SaveChanges();
                return NotFound();
        }
    }
}

