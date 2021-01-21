using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Global.Dados;
using Global.Dados.Entidades;
using Global.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace Global.Controllers
{
    
    public class InscricoesController : Controller
    {
        private readonly IUserHelper userHelper;

        private readonly DataContext _context;

        public InscricoesController(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            this.userHelper = userHelper;
        }
        [Authorize]
        // GET: Inscricoes
        public async Task<IActionResult> Index2()

        {
            return View(await _context.Inscricoes.ToListAsync());
        }

        // GET: Inscricoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscricao = await _context.Inscricoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inscricao == null)
            {
                return NotFound();
            }

            return View(inscricao);
        }

        
        // GET: Inscricoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscricao = await _context.Inscricoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inscricao == null)
            {
                return NotFound();
            }

            return View(inscricao);
        }

        // POST: Inscricoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inscricao = await _context.Inscricoes.FindAsync(id);
            _context.Inscricoes.Remove(inscricao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index2));
        }

        private bool InscricaoExists(int id)
        {
            return _context.Inscricoes.Any(e => e.Id == id);
        }
    }
}
