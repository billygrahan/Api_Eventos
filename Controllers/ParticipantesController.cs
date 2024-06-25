using Api_Eventos.Context;
using Microsoft.AspNetCore.Mvc;
using Api_Eventos.Models;
using Microsoft.EntityFrameworkCore;

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
        public ActionResult<IEnumerable<Participante>> Get()
        {
            try
            {
                return _context.Participantes.ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id:int}", Name = "ObterParticipante")]
        public ActionResult<Participante> Get(int id)
        {
            var participante = _context.Participantes.FirstOrDefault(p => p.ParticipanteId == id);

            if (participante == null) NotFound("Participante não encontrado!!");
            return participante;
        }

        [HttpGet("{id:int}/Eventos")]
        public ActionResult<IEnumerable<Evento>> GetEventosByParticipante(int id)
        {
            // Encontrar o participante pelo id fornecido
            var participante = _context.Participantes.Find(id);

            if (participante == null)
            {
                return NotFound("Participante não encontrado!!");
            }

            // Carregar todos os eventos do banco de dados
            var eventos = _context.Eventos.ToList();

            // Filtrar eventos que contêm o participante
            var eventosDoParticipante = eventos.Where(e => e.ParticipanteIds.Contains(id)).ToList();

            return Ok(eventosDoParticipante);
        }




        [HttpPost]
        public ActionResult Post([FromBody] Participante participante)
        {

            _context.Participantes.Add(participante);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterParticipante", new { id = participante.ParticipanteId }, participante);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Participante participante)
        {
            if (id != participante.ParticipanteId) return BadRequest();

            _context.Entry(participante).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(participante);
        }


        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var participante = _context.Participantes.FirstOrDefault(p => p.ParticipanteId == id);
            if (participante == null) return NotFound("evento não encontrado!!!");
            _context.Participantes.Remove(participante);
            _context.SaveChanges();
            return Ok(participante);
        }
    }
}

