using Api_Eventos.Context;
using Microsoft.AspNetCore.Mvc;
using Api_Eventos.Models;

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


        [HttpPost]
        public ActionResult Post([FromBody] Evento evento)
        {

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
    }
}
