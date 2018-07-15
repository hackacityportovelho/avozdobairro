using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ComCity.Data;
using ComCity.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ComCity.Controllers
{
    public class ProjetosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjetosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Projetos.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projetos
                .SingleOrDefaultAsync(m => m.Id == id);
            if (projeto == null)
            {
                return NotFound();
            }

            return View(projeto);
        }

        public IActionResult Create()
        {
            ViewBag.AreaId = new SelectList(_context.Areas.ToList(), "Id", "Descricao");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Projeto projeto)
        {
            if (ModelState.IsValid)
            {
                var filePath = Path.GetTempFileName();
                foreach (var formFile in Request.Form.Files)
                {
                    if (formFile.Length > 0)
                    {
                        using (var inputStream = new FileStream(filePath, FileMode.Create))
                        {
                            // read file to stream
                            await formFile.CopyToAsync(inputStream);
                            // stream to byte array
                            projeto.Imagem = new byte[inputStream.Length];
                        }
                    }
                }
                _context.Add(projeto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Areas = new SelectList(_context.Areas.ToList(), "Id", "Descricao", projeto.AreaId);
            return View(projeto);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projetos.SingleOrDefaultAsync(m => m.Id == id);
            if (projeto == null)
            {
                return NotFound();
            }
            ViewBag.Areas = new SelectList(_context.Areas.ToList(), "Id", "Descricao", projeto.AreaId);
            return View(projeto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Projeto projeto)
        {
            if (id != projeto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var filePath = Path.GetTempFileName();
                    foreach (var formFile in Request.Form.Files)
                    {
                        if (formFile.Length > 0)
                        {
                            using (var inputStream = new FileStream(filePath, FileMode.Create))
                            {
                                // read file to stream
                                await formFile.CopyToAsync(inputStream);
                                // stream to byte array
                                projeto.Imagem = new byte[inputStream.Length];
                            }
                        }
                    }
                    _context.Update(projeto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjetoExists(projeto.Id))
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
            ViewBag.Areas = new SelectList(_context.Areas.ToList(), "Id", "Descricao", projeto.AreaId);
            return View(projeto);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projetos
                .SingleOrDefaultAsync(m => m.Id == id);
            if (projeto == null)
            {
                return NotFound();
            }

            return View(projeto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projeto = await _context.Projetos.SingleOrDefaultAsync(m => m.Id == id);
            _context.Projetos.Remove(projeto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjetoExists(int id)
        {
            return _context.Projetos.Any(e => e.Id == id);
        }
    }
}
