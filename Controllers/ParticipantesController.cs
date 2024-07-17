using Api_Eventos.Context;
using Microsoft.AspNetCore.Mvc;
using Api_Eventos.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Api_Eventos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParticipantesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ParticipantesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Policy = "ParticipantePolicy")]
        public async Task<ActionResult<IEnumerable<Participante>>> Get()
        {
            try
            {
                return await _context.Participantes.ToListAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id:int}", Name = "ObterParticipante")]
        public async Task<ActionResult<Participante>> Get(int id)
        {
            var participante = await _context.Participantes.FirstOrDefaultAsync(p => p.ParticipanteId == id);

            if (participante == null)
            {
                return NotFound("Participante não encontrado!!");
            }
            return participante;
        }

        [HttpGet("{id:int}/Eventos")]
        public async Task<ActionResult<IEnumerable<Evento>>> GetEventosByParticipante(int id)
        {
            // Encontrar o participante pelo id fornecido
            var participante = await _context.Participantes.FindAsync(id);

            if (participante == null)
            {
                return NotFound("Participante não encontrado!!");
            }

            // Carregar todos os eventos do banco de dados
            var eventos = await _context.Eventos.ToListAsync();

            // Filtrar eventos que contêm o participante
            var eventosDoParticipante = eventos.Where(e => e.ParticipanteIds.Contains(id)).ToList();

            return Ok(eventosDoParticipante);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Participante participante)
        {
            _context.Participantes.Add(participante);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("ObterParticipante", new { id = participante.ParticipanteId }, participante);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Participante participante)
        {
            if (id != participante.ParticipanteId)
            {
                return BadRequest();
            }

            _context.Entry(participante).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(participante);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var participante = await _context.Participantes.FirstOrDefaultAsync(p => p.ParticipanteId == id);
            if (participante == null)
            {
                return NotFound("Participante não encontrado!!!");
            }
            _context.Participantes.Remove(participante);
            await _context.SaveChangesAsync();
            return Ok(participante);
        }
    }
}
