using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DesafioCRUDItau.Models;

namespace DesafioCRUDItau.Controllers
{
    public class GravidadesController : Controller
    {
        private readonly Context _context;

        public GravidadesController(Context context)
        {
            _context = context;
        }

        // GET: Gravidades
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gravidades.ToListAsync());
        }

        // GET: Gravidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gravidade = await _context.Gravidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gravidade == null)
            {
                return NotFound();
            }

            return View(gravidade);
        }

        // GET: Gravidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gravidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao")] Gravidade gravidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gravidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gravidade);
        }

        // GET: Gravidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gravidade = await _context.Gravidades.FindAsync(id);
            if (gravidade == null)
            {
                return NotFound();
            }
            return View(gravidade);
        }

        // POST: Gravidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao")] Gravidade gravidade)
        {
            if (id != gravidade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gravidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GravidadeExists(gravidade.Id))
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
            return View(gravidade);
        }

        // GET: Gravidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gravidade = await _context.Gravidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gravidade == null)
            {
                return NotFound();
            }

            return View(gravidade);
        }

        // POST: Gravidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gravidade = await _context.Gravidades.FindAsync(id);
            _context.Gravidades.Remove(gravidade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GravidadeExists(int id)
        {
            return _context.Gravidades.Any(e => e.Id == id);
        }
    }
}
