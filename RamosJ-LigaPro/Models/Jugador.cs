using System.ComponentModel.DataAnnotations;

namespace RamosJ_LigaPro.Models
{
    public class Jugador
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Dorsal { get; set; }
        public int Goles { get; set; }
        public int Asistencias { get; set; }
        public int PartidosJugados { get; set; }
        public int Sueldo { get; set; }
        public ICollection<Plantilla>? Plantillas { get; set; } = new List<Plantilla>();

    }
}
