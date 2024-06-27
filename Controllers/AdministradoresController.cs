using Microsoft.AspNetCore.Mvc;
using Api_Eventos.Context;
using Api_Eventos.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api_Eventos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdministradoresController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AdministradoresController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Administrador>> GetTudo()
        {
            try
            {
                return _context.Administradores.Include(p => p.Eventos).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id:int}", Name = "ObterAdministrador")]
        public async Task<ActionResult<Administrador>> Get(int id)
        {
            var administrador = await _context.Administradores.FirstOrDefaultAsync(a => a.AdministradorId == id);
            if (administrador == null) return NotFound("Administrador não encontrado!");

            return Ok(administrador);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Administrador administrador)
        {
            _context.Administradores.Add(administrador);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("ObterAdministrador", new { id = administrador.AdministradorId }, administrador);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Administrador administrador)
        {
            if (id != administrador.AdministradorId) return BadRequest("Administradores incongruentes!");
            _context.Entry(administrador).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(administrador);
        }
    }
}
