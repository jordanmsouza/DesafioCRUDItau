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
    public class TipoSolicitacaosController : Controller
    {
        private readonly Context _context;

        public TipoSolicitacaosController(Context context)
        {
            _context = context;
        }

        // GET: TipoSolicitacaos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoSolicitacaos.ToListAsync());
        }

        // GET: TipoSolicitacaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoSolicitacao = await _context.TipoSolicitacaos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoSolicitacao == null)
            {
                return NotFound();
            }

            return View(tipoSolicitacao);
        }

        // GET: TipoSolicitacaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoSolicitacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao")] TipoSolicitacao tipoSolicitacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoSolicitacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoSolicitacao);
        }

        // GET: TipoSolicitacaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoSolicitacao = await _context.TipoSolicitacaos.FindAsync(id);
            if (tipoSolicitacao == null)
            {
                return NotFound();
            }
            return View(tipoSolicitacao);
        }

        // POST: TipoSolicitacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao")] TipoSolicitacao tipoSolicitacao)
        {
            if (id != tipoSolicitacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoSolicitacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoSolicitacaoExists(tipoSolicitacao.Id))
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
            return View(tipoSolicitacao);
        }

        // GET: TipoSolicitacaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoSolicitacao = await _context.TipoSolicitacaos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoSolicitacao == null)
            {
                return NotFound();
            }

            return View(tipoSolicitacao);
        }

        // POST: TipoSolicitacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoSolicitacao = await _context.TipoSolicitacaos.FindAsync(id);
            _context.TipoSolicitacaos.Remove(tipoSolicitacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoSolicitacaoExists(int id)
        {
            return _context.TipoSolicitacaos.Any(e => e.Id == id);
        }
    }
}
