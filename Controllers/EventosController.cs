using Api_Eventos.Context;
using Microsoft.AspNetCore.Mvc;
using Api_Eventos.Models;
using Microsoft.EntityFrameworkCore;

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
        public ActionResult<IEnumerable<Evento>> Get()
        {
            try
            {
                return _context.Eventos.ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id:int}", Name = "ObterEvento")]
        public ActionResult<Evento> Get(int id)
        {
            var evento = _context.Eventos.FirstOrDefault(p => p.EventoId == id);

            if (evento == null)
            {
                return NotFound("Evento não encontrado!!");
            }
            return evento;
        }


        [HttpPost("Criar Evento")]
        public ActionResult Post([FromBody] Evento evento)
        {
            //evento.ParticipanteIds = new List<int>(); // Garantir que a lista seja inicializada vazia

            _context.Eventos.Add(evento);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterEvento", new { id = evento.EventoId }, evento);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Evento evento)
        {
            _context.Entry(evento).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return Ok(evento);
        }


        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var evento = _context.Eventos.FirstOrDefault(p => p.EventoId == id);
            if (evento == null)
            {
                return NotFound("evento não encontrado!!!");
            }
            _context.Eventos.Remove(evento);
            _context.SaveChanges();
            return Ok(evento);
        }

        [HttpPatch("{id:int}/AdicionarParticipante/{participanteId:int}")]
        public ActionResult AddParticipante(int id, int participanteId)
        {
            // Encontrar o evento pelo id fornecido
            var evento = _context.Eventos.FirstOrDefault(e => e.EventoId == id);

            if (evento == null)
            {
                return NotFound("Evento não encontrado!!");
            }

            // Verificar se o participante existe
            var participante = _context.Participantes.Find(participanteId);
            if (participante == null)
            {
                return NotFound("Participante não encontrado!!");
            }

            // Verificar se o participante já está na lista
            if (evento.ParticipanteIds.Contains(participanteId))
            {
                return BadRequest("Participante já está associado ao evento.");
            }

            // Adicionar o participante à lista do evento
            evento.ParticipanteIds.Add(participanteId);

            // Atualizar o contexto
            _context.SaveChanges();

            return Ok(evento);
        }

        [HttpPatch("{participanteId}/RemoverEvento/{eventoId}")]
        public ActionResult Patch(int participanteId, int eventoId)
        {
            // Buscar o participante e o evento por suas IDs
            var participante = _context.Participantes.Find(participanteId);
            var evento = _context.Eventos.Find(eventoId);

            // Verificar se o participante e o evento existem
            if (participante == null || evento == null)
            {
                return NotFound("Participante ou evento não encontrado(s).");
            }

            // Verificar se o participante já está associado ao evento
            if (!evento.ParticipanteIds.Contains(participanteId))
            {
                return BadRequest("Participante não está associado ao evento.");
            }

            // Remover o participante da lista ParticipanteIds do evento
            evento.ParticipanteIds.Remove(participanteId);

            // Atualizar o contexto e salvar as alterações
            _context.SaveChanges();

            //var evento_atualizado = evento.ToString();
            return Ok(evento);
        }


    }
}
