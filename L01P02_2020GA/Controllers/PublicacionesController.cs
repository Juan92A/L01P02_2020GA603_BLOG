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
    public class PublicacionesController : Controller
    {
        private readonly blogDBContext _context;

        public PublicacionesController(blogDBContext context)
        {
            _context = context;
        }

        // GET: Publicaciones
        public async Task<IActionResult> Index()
        {
              return _context.publicaciones != null ? 
                          View(await _context.publicaciones.ToListAsync()) :
                          Problem("Entity set 'blogDBContext.publicaciones'  is null.");
        }

        // GET: Publicaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.publicaciones == null)
            {
                return NotFound();
            }

            var publicaciones = await _context.publicaciones
                .FirstOrDefaultAsync(m => m.PublicacionId == id);
            if (publicaciones == null)
            {
                return NotFound();
            }

            return View(publicaciones);
        }

        // GET: Publicaciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Publicaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PublicacionId,Titulo,Descripcion,UsuarioId")] Publicaciones publicaciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publicaciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(publicaciones);
        }

        // GET: Publicaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.publicaciones == null)
            {
                return NotFound();
            }

            var publicaciones = await _context.publicaciones.FindAsync(id);
            if (publicaciones == null)
            {
                return NotFound();
            }
            return View(publicaciones);
        }

        // POST: Publicaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PublicacionId,Titulo,Descripcion,UsuarioId")] Publicaciones publicaciones)
        {
            if (id != publicaciones.PublicacionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publicaciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublicacionesExists(publicaciones.PublicacionId))
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
            return View(publicaciones);
        }

        // GET: Publicaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.publicaciones == null)
            {
                return NotFound();
            }

            var publicaciones = await _context.publicaciones
                .FirstOrDefaultAsync(m => m.PublicacionId == id);
            if (publicaciones == null)
            {
                return NotFound();
            }

            return View(publicaciones);
        }

        // POST: Publicaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.publicaciones == null)
            {
                return Problem("Entity set 'blogDBContext.publicaciones'  is null.");
            }
            var publicaciones = await _context.publicaciones.FindAsync(id);
            if (publicaciones != null)
            {
                _context.publicaciones.Remove(publicaciones);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PublicacionesExists(int id)
        {
          return (_context.publicaciones?.Any(e => e.PublicacionId == id)).GetValueOrDefault();
        }
    }
}
