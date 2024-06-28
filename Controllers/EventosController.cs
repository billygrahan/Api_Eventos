using Api_Eventos.Context;
using Microsoft.AspNetCore.Mvc;
using Api_Eventos.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Api_Eventos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EventosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evento>>> Get()
        {
            try
            {
                return await _context.Eventos.ToListAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id:int}", Name = "ObterEvento")]
        public async Task<ActionResult<Evento>> Get(int id)
        {
            var evento = await _context.Eventos.FirstOrDefaultAsync(p => p.EventoId == id);

            if (evento == null)
            {
                return NotFound("Evento não encontrado!!");
            }
            return evento;
        }

        [HttpPost("Criar Evento")]
        public async Task<ActionResult> Post([FromBody] Evento evento)
        {
            _context.Eventos.Add(evento);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("ObterEvento", new { id = evento.EventoId }, evento);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Evento evento)
        {
            _context.Entry(evento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(evento);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var evento = await _context.Eventos.FirstOrDefaultAsync(p => p.EventoId == id);
            if (evento == null)
            {
                return NotFound("evento não encontrado!!!");
            }
            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();
            return Ok(evento);
        }

        [HttpPatch("AdicionarParticipante_Evento/{id:int}/{participanteId:int}")]
        public async Task<ActionResult> AddParticipante(int id, int participanteId)
        {
            var evento = await _context.Eventos.FirstOrDefaultAsync(e => e.EventoId == id);

            if (evento == null)
            {
                return NotFound("Evento não encontrado!!");
            }

            var participante = await _context.Participantes.FindAsync(participanteId);
            if (participante == null)
            {
                return NotFound("Participante não encontrado!!");
            }

            if (evento.ParticipanteIds.Contains(participanteId))
            {
                return BadRequest("Participante já está associado ao evento.");
            }

            evento.ParticipanteIds.Add(participanteId);
            await _context.SaveChangesAsync();

            return Ok(evento);
        }

        [HttpPatch("RemoverParticioante_Evento/{participanteId}/{eventoId}")]
        public async Task<ActionResult> Patch(int participanteId, int eventoId)
        {
            var participante = await _context.Participantes.FindAsync(participanteId);
            var evento = await _context.Eventos.FindAsync(eventoId);

            if (participante == null || evento == null)
            {
                return NotFound("Participante ou evento não encontrado(s).");
            }

            if (!evento.ParticipanteIds.Contains(participanteId))
            {
                return BadRequest("Participante não está associado ao evento.");
            }

            evento.ParticipanteIds.Remove(participanteId);
            await _context.SaveChangesAsync();

            return Ok(evento);
        }
    }
}
