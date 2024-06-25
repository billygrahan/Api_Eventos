using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace Api_Eventos.Models
{
    [Table("Eventos")]
    public class Evento
    {
        [Key]
        public int EventoId { get; set; }

        [Required]
        public string? Nome { get; set; }

        [Required]
        public int Numero_Participantes { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data_Inicio { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data_Fim { get; set; }

        public List<int> ParticipanteIds { get; set; } = new List<int>();
    }

}
