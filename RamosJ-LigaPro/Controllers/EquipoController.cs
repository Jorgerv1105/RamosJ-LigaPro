using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RamosJ_LigaPro.Models;
using RamosJ_LigaPro.Repositories;

namespace RamosJ_LigaPro.Controllers
{
    public class EquipoController : Controller
    {
        EquipoRepository _repository;
        public EquipoController()
        {
            _repository = new EquipoRepository();
        }
        public ActionResult List()
        {
 
            var equipos = _repository.DevuelveListadoEquipos();

            equipos = equipos.OrderBy(item => item.PartidosGanados);
            //equipos = equipos.Where(item => item.Nombre == "Barcelona SC");
            return View(equipos);

        }
        public ActionResult Create()

        {
            return View();
        }

        public ActionResult Edit(int Id)

        {
    
            var equipo = _repository.DevuelveEquipoPorID(Id);
            return View(equipo);
        }
        [HttpPost]
        public ActionResult Edit(int Id, Equipo equipo)
        {
            try
            {
  
                _repository.ActualizaEquipo(Id, equipo);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }
           
    }
}
