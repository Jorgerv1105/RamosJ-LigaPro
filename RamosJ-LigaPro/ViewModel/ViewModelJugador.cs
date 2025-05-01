using RamosJ_LigaPro.Models;

namespace RamosJ_LigaPro.ViewModel
{
    public class ViewModelJugador
    {
        public IEnumerable<Equipo> Equipos { get; set; }
        public IEnumerable<Jugador> Jugadores { get; set; }
    }
}
