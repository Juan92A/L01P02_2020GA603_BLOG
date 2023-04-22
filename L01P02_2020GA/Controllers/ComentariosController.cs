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
    public class ComentariosController : Controller
    {
        private readonly blogDBContext _context;

        public ComentariosController(blogDBContext context)
        {
            _context = context;
        }

        // GET: Comentarios
        public async Task<IActionResult> Index()
        {
              return _context.comentarios != null ? 
                          View(await _context.comentarios.ToListAsync()) :
                          Problem("Entity set 'blogDBContext.comentarios'  is null.");
        }

        // GET: Comentarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.comentarios == null)
            {
                return NotFound();
            }

            var comentarios = await _context.comentarios
                .FirstOrDefaultAsync(m => m.ComentarioId == id);
            if (comentarios == null)
            {
                return NotFound();
            }

            return View(comentarios);
        }

        // GET: Comentarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Comentarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComentarioId,PublicacionId,Comentario,UsuarioId")] Comentarios comentarios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comentarios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comentarios);
        }

        // GET: Comentarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.comentarios == null)
            {
                return NotFound();
            }

            var comentarios = await _context.comentarios.FindAsync(id);
            if (comentarios == null)
            {
                return NotFound();
            }
            return View(comentarios);
        }

        // POST: Comentarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComentarioId,PublicacionId,Comentario,UsuarioId")] Comentarios comentarios)
        {
            if (id != comentarios.ComentarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comentarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComentariosExists(comentarios.ComentarioId))
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
            return View(comentarios);
        }

        // GET: Comentarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.comentarios == null)
            {
                return NotFound();
            }

            var comentarios = await _context.comentarios
                .FirstOrDefaultAsync(m => m.ComentarioId == id);
            if (comentarios == null)
            {
                return NotFound();
            }

            return View(comentarios);
        }

        // POST: Comentarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.comentarios == null)
            {
                return Problem("Entity set 'blogDBContext.comentarios'  is null.");
            }
            var comentarios = await _context.comentarios.FindAsync(id);
            if (comentarios != null)
            {
                _context.comentarios.Remove(comentarios);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComentariosExists(int id)
        {
          return (_context.comentarios?.Any(e => e.ComentarioId == id)).GetValueOrDefault();
        }
    }
}
