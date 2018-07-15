using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComCity.Data;
using ComCity.Models;

namespace ComCity.Controllers
{
    public class EnquetesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnquetesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Enquetes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Enquetes.ToListAsync());
        }

        // GET: Enquetes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enquete = await _context.Enquetes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (enquete == null)
            {
                return NotFound();
            }

            return View(enquete);
        }

        // GET: Enquetes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enquetes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao")] Enquete enquete)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enquete);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enquete);
        }

        // GET: Enquetes/Edit/5
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
            return View(enquete);
        }

        // POST: Enquetes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao")] Enquete enquete)
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
            return View(enquete);
        }

        // GET: Enquetes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enquete = await _context.Enquetes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (enquete == null)
            {
                return NotFound();
            }

            return View(enquete);
        }

        // POST: Enquetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
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
