using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RamosJ_LigaPro.Models;

namespace RamosJ_LigaPro.Controllers
{
    public class EquipoController : Controller
    {
        public ActionResult List()
        {
            List<Equipo> equipos = new List<Equipo>();
            Equipo equipo1 = new Equipo
            {
                Id = 1,
                Nombre = "Barcelona SC",
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
            return View(equipos);
        }
    }
}
