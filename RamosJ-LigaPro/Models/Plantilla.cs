namespace RamosJ_LigaPro.Models
{
    public class Plantilla
    {
        public int EquipoId { get; set; }
        public Equipo Equipo { get; set; }

        public int JugadorId { get; set; }
        public Jugador Jugador { get; set; }
    }
}
