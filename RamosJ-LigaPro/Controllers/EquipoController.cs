using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RamosJ_LigaPro.Models;
using RamosJ_LigaPro.Repositories;

namespace RamosJ_LigaPro.Controllers
{
    public class EquipoController : Controller
    {
        public ActionResult List()
        {
            EquipoRepository repository = new EquipoRepository();
            var equipos = repository.DevuelveListadoEquipos();

            equipos = equipos.OrderBy(item => item.PartidosGanados);
            equipos = equipos.Where(item => item.Nombre == "Liga de Quito");
            return View(equipos);
        }
    }
}
