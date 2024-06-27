
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Eventos.Models
{
    [Table("Administradores")]
    public class Administrador
    {
        public Administrador()
        {
            Eventos = new Collection<Evento>();
        }
        [Key]
        public int AdministradorId { get; set; }

        [Required]
        public string? Nome { get; set; }

        [Required]
        public string? EMail { get; set; }

        public ICollection<Evento>? Eventos { get; set; }
    }
}
