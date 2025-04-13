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
                PartidosPerdidos = 1,
                Puntos = 23
            };
            equipos.Add(equipo1);
            Equipo equipo2 = new Equipo
            {
                Id = 2,
                Nombre = "Emelec",
                PartidosJugados = 10,
                PartidosGanados = 5,
                PartidosEmpatados = 3,
                PartidosPerdidos = 2,
                Puntos = 18
            };
            equipos.Add(equipo2);
            Equipo equipo3 = new Equipo
            {
                Id = 3,
                Nombre = "Liga",
                PartidosJugados = 10,
                PartidosGanados = 4,
                PartidosEmpatados = 4,
                PartidosPerdidos = 2,
                Puntos = 16
            };
            equipos.Add(equipo3);
            Equipo equipo4 = new Equipo
            {
                Id = 4,
                Nombre = "Libertad FC",
                PartidosJugados = 10,
                PartidosGanados = 3,
                PartidosEmpatados = 5,
                PartidosPerdidos = 2,
                Puntos = 14
            };
            equipos.Add(equipo4);
            Equipo equipo5 = new Equipo
            {
                Id = 5,
                Nombre = "U.Catolica",
                PartidosJugados = 10,
                PartidosGanados = 2,
                PartidosEmpatados = 6,
                PartidosPerdidos = 2,
                Puntos = 8
            };
            equipos.Add(equipo5);
            return equipos;
        }
        public Equipo DevuelveEquipoPorID(int Id)
        {

            var equipo = Equipos.First(item => item.Id == Id);
            return equipo;
        }
        public bool ActualizaEquipo(int Id, Equipo equipo)
        {
            return true;
        }
    }
}
