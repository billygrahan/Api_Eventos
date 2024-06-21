using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Eventos.Models
{
    [Table("Paticipantes")]
    public class Participante
    {
        [Key]
        public int ParticipanteId { get; set; }

        [Required]
        public string? Nome { get; set; }

    }
}
