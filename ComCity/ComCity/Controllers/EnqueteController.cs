using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComCity.Data;
using ComCity.Models;

namespace ComCity.Controllers
{
    public class EnqueteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnqueteController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Enquetes.Include(e => e.Projeto);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enquete = await _context.Enquetes
                .Include(e => e.Projeto)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (enquete == null)
            {
                return NotFound();
            }

            return View(enquete);
        }

        public IActionResult Create()
        {
            ViewData["ProjetoId"] = new SelectList(_context.Projetos, "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjetoId,Descricao")] Enquete enquete)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enquete);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjetoId"] = new SelectList(_context.Projetos, "Id", "Id", enquete.ProjetoId);
            return View(enquete);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enquete = await _context.Enquetes.SingleOrDefaultAsync(m => m.Id == id);
            if (enquete == null)
            {
                return NotFound();
            }
            ViewData["ProjetoId"] = new SelectList(_context.Projetos, "Id", "Id", enquete.ProjetoId);
            return View(enquete);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjetoId,Descricao")] Enquete enquete)
        {
            if (id != enquete.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enquete);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnqueteExists(enquete.Id))
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
            ViewData["ProjetoId"] = new SelectList(_context.Projetos, "Id", "Id", enquete.ProjetoId);
            return View(enquete);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enquete = await _context.Enquetes
                .Include(e => e.Projeto)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (enquete == null)
            {
                return NotFound();
            }

            return View(enquete);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enquete = await _context.Enquetes.SingleOrDefaultAsync(m => m.Id == id);
            _context.Enquetes.Remove(enquete);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnqueteExists(int id)
        {
            return _context.Enquetes.Any(e => e.Id == id);
        }
    }
}
