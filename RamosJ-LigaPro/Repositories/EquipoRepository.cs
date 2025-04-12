using RamosJ_LigaPro.Models;

namespace RamosJ_LigaPro.Repositories
{
    public class EquipoRepository
    {
        public IEnumerable<Equipo> Equipos;
        public EquipoRepository() 
        {
            Equipos = DevuelveListadoEquipos();
        }
        public IEnumerable<Equipo> DevuelveListadoEquipos()
        {
            List<Equipo> equipos = new List<Equipo>();
            Equipo equipo1 = new Equipo
            {
                Id = 1,
                Nombre = "Barcelona",
                PartidosJugados = 10,
                PartidosGanados = 7,
                PartidosEmpatados = 2,
                PartidosPerdidos = 1
            };
            equipos.Add(equipo1);
            Equipo equipo2 = new Equipo
            {
                Id = 2,
                Nombre = "Emelec",
                PartidosJugados = 10,
                PartidosGanados = 5,
                PartidosEmpatados = 3,
                PartidosPerdidos = 2
            };
            equipos.Add(equipo2);
            return equipos;
        }
        public Equipo DevuelveEquipoPorID(int Id)
        {

            var equipo = Equipos.First(item=> item.Id == Id);
            return equipo;
        }
        public bool ActualizaEquipo(int Id, Equipo equipo)
        {
            return true;
        }
    }
}
