using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RamosJ_LigaPro.Models
{
    public class Equipo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [DisplayName("Nombre del equipo")]
        public string Nombre { get; set; }
        [Range(0, 100)]
        public string PartidosJugados { get; set; }
        [Range(0, 100)]
        public string PartidosGanados { get; set; }
        [Range(0, 100)]
        public string PartidosEmpatados { get; set; }
        [Range(0, 100)]
        public string PartidosPerdidos { get; set; }
    }
}
