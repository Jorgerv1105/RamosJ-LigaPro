using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RamosJ_LigaPro.Models;

namespace RamosJ_LigaPro.Controllers
{
    public class JugadoresController : Controller
    {
        private readonly DbContext _context;

        public JugadoresController(DbContext context)
        {
            _context = context;
        }

        // GET: Jugadores
        public async Task<IActionResult> Index(int? equipoId)
        {
            var jugadores = _context.Jugador
                .Include(j => j.Plantillas)
                    .ThenInclude(p => p.Equipo)
                .AsQueryable();

            if (equipoId.HasValue)
            {
                jugadores = jugadores.Where(j =>
                    j.Plantillas.Any(p => p.EquipoId == equipoId.Value));
            }

            ViewBag.Equipos = new SelectList(_context.Equipo, "Id", "Nombre", equipoId);
            return View(await jugadores.ToListAsync());
        }

        // GET: Jugadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var jugador = await _context.Jugador
                .Include(j => j.Plantillas)
                    .ThenInclude(p => p.Equipo)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (jugador == null) return NotFound();

            return View(jugador);
        }

        // GET: Jugadores/Create
        public IActionResult Create()
        {
            ViewBag.Equipos = new SelectList(_context.Equipo, "Id", "Nombre");
            return View();
        }

        // POST: Jugadores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Jugador jugador, int equipoId)
        {
            if (ModelState.IsValid)
            {
                _context.Jugador.Add(jugador);
                await _context.SaveChangesAsync();

                _context.Plantilla.Add(new Plantilla
                {
                    JugadorId = jugador.Id,
                    EquipoId = equipoId
                });
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Equipos = new SelectList(_context.Equipo, "Id", "Nombre", equipoId);
            return View(jugador);
        }

        // GET: Jugadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var jugador = await _context.Jugador.FindAsync(id);
            if (jugador == null) return NotFound();

            return View(jugador);
        }

        // POST: Jugadores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Jugador jugador)
        {
            if (id != jugador.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jugador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Jugador.Any(j => j.Id == jugador.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            return View(jugador);
        }

        // GET: Jugadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var jugador = await _context.Jugador
                .FirstOrDefaultAsync(m => m.Id == id);

            if (jugador == null) return NotFound();

            return View(jugador);
        }

        // POST: Jugadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jugador = await _context.Jugador.FindAsync(id);
            if (jugador != null)
            {
                var plantillas = _context.Plantilla.Where(p => p.JugadorId == id);
                _context.Plantilla.RemoveRange(plantillas);

                _context.Jugador.Remove(jugador);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Reporte()
        {

            var goleadores = await _context.Jugador
                .OrderByDescending(j => j.Goles)
                .Take(5)
                .ToListAsync();

            var jugadoresConMasAsistencias = await _context.Jugador
                .OrderByDescending(j => j.Asistencias)
                .Take(5)
                .ToListAsync();


            var equiposConMasPresupuesto = await _context.Equipo
                .Select(e => new
                {
                    Equipo = e.Nombre,
                    Presupuesto = e.Plantillas.Sum(p => p.Jugador.Sueldo)
                })
                .OrderByDescending(e => e.Presupuesto)
                .Take(5)
                .ToListAsync();

            ViewData["Goleadores"] = goleadores;
            ViewData["JugadoresConMasAsistencias"] = jugadoresConMasAsistencias;
            ViewData["EquiposConMasPresupuesto"] = equiposConMasPresupuesto;

            return View();
        }
    }

}
