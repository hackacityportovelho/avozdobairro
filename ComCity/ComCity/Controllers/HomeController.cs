using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ComCity.Models;
using ComCity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace ComCity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index(string search = "")
        {
            search = (search is null ? "" : search.ToLower()); 

            var projetos = await db.Projetos
                .Include(a => a.Area)
                .Where(a => 
                    a.Nome.ToLower().Contains(search) ||
                    a.Bairro.ToLower().Contains(search)
                ) 
                .ToListAsync();

            return View(projetos);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> ListarEnquetes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projeto = await db.Projetos.Include(t => t.Enquetes)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (projeto == null)
            {
                return NotFound();
            }

            return View(projeto);
        }
    }
}
