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
    public class ChamadosController : Controller
    {
        private readonly Context _context;

        public ChamadosController(Context context)
        {
            _context = context;
        }

        // GET: Chamados
        public async Task<IActionResult> Index()
        {
            var context = _context.Chamados.Include(c => c.Gravidade).Include(c => c.TipoSolicitacao).Include(c => c.Usuario);
            return View(await context.ToListAsync());
        }

        // GET: Chamados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chamado = await _context.Chamados
                .Include(c => c.Gravidade)
                .Include(c => c.TipoSolicitacao)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chamado == null)
            {
                return NotFound();
            }

            return View(chamado);
        }

        // GET: Chamados/Create
        public IActionResult Create()
        {
            ViewData["GravidadeId"] = new SelectList(_context.Gravidades, "Id", "Descricao");
            ViewData["TipoSolicitacaoId"] = new SelectList(_context.TipoSolicitacaos, "Id", "Descricao");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nome");
            return View();
        }

        // POST: Chamados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GravidadeId,TipoSolicitacaoId,Assunto,Menssagem,UsuarioId")] Chamado chamado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chamado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GravidadeId"] = new SelectList(_context.Gravidades, "Id", "Descricao", chamado.GravidadeId);
            ViewData["TipoSolicitacaoId"] = new SelectList(_context.TipoSolicitacaos, "Id", "Descricao", chamado.TipoSolicitacaoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nome", chamado.UsuarioId);
            return View(chamado);
        }

        // GET: Chamados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chamado = await _context.Chamados.FindAsync(id);
            if (chamado == null)
            {
                return NotFound();
            }
            ViewData["GravidadeId"] = new SelectList(_context.Gravidades, "Id", "Descricao", chamado.GravidadeId);
            ViewData["TipoSolicitacaoId"] = new SelectList(_context.TipoSolicitacaos, "Id", "Descricao", chamado.TipoSolicitacaoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nome", chamado.UsuarioId);
            return View(chamado);
        }

        // POST: Chamados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GravidadeId,TipoSolicitacaoId,Assunto,Menssagem,UsuarioId")] Chamado chamado)
        {
            if (id != chamado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chamado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChamadoExists(chamado.Id))
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
            ViewData["GravidadeId"] = new SelectList(_context.Gravidades, "Id", "Descricao", chamado.GravidadeId);
            ViewData["TipoSolicitacaoId"] = new SelectList(_context.TipoSolicitacaos, "Id", "Descricao", chamado.TipoSolicitacaoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nome", chamado.UsuarioId);
            return View(chamado);
        }

        // GET: Chamados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chamado = await _context.Chamados
                .Include(c => c.Gravidade)
                .Include(c => c.TipoSolicitacao)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chamado == null)
            {
                return NotFound();
            }

            return View(chamado);
        }

        // POST: Chamados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chamado = await _context.Chamados.FindAsync(id);
            _context.Chamados.Remove(chamado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChamadoExists(int id)
        {
            return _context.Chamados.Any(e => e.Id == id);
        }
    }
}
