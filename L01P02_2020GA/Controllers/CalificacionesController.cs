using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using L01P02_2020GA603.Models;
using L01P02_2020GA603.Data;

namespace L01P02_2020GA.Controllers
{
    public class CalificacionesController : Controller
    {
        private readonly blogDBContext _context;

        public CalificacionesController(blogDBContext context)
        {
            _context = context;
        }

        // GET: Calificaciones
        public async Task<IActionResult> Index()
        {
              return _context.calificaciones != null ? 
                          View(await _context.calificaciones.ToListAsync()) :
                          Problem("Entity set 'blogDBContext.calificaciones'  is null.");
        }

        // GET: Calificaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.calificaciones == null)
            {
                return NotFound();
            }

            var calificaciones = await _context.calificaciones
                .FirstOrDefaultAsync(m => m.CalificacionId == id);
            if (calificaciones == null)
            {
                return NotFound();
            }

            return View(calificaciones);
        }

        // GET: Calificaciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Calificaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CalificacionId,PublicacionId,UsuarioId,Calificacion")] Calificaciones calificaciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calificaciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(calificaciones);
        }

        // GET: Calificaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.calificaciones == null)
            {
                return NotFound();
            }

            var calificaciones = await _context.calificaciones.FindAsync(id);
            if (calificaciones == null)
            {
                return NotFound();
            }
            return View(calificaciones);
        }

        // POST: Calificaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CalificacionId,PublicacionId,UsuarioId,Calificacion")] Calificaciones calificaciones)
        {
            if (id != calificaciones.CalificacionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calificaciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalificacionesExists(calificaciones.CalificacionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(calificaciones);
        }

        // GET: Calificaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.calificaciones == null)
            {
                return NotFound();
            }

            var calificaciones = await _context.calificaciones
                .FirstOrDefaultAsync(m => m.CalificacionId == id);
            if (calificaciones == null)
            {
                return NotFound();
            }

            return View(calificaciones);
        }

        // POST: Calificaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.calificaciones == null)
            {
                return Problem("Entity set 'blogDBContext.calificaciones'  is null.");
            }
            var calificaciones = await _context.calificaciones.FindAsync(id);
            if (calificaciones != null)
            {
                _context.calificaciones.Remove(calificaciones);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalificacionesExists(int id)
        {
          return (_context.calificaciones?.Any(e => e.CalificacionId == id)).GetValueOrDefault();
        }
    }
}
