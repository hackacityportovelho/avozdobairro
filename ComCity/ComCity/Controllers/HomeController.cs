using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ComCity.Models;
using ComCity.Data;
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
                .Where(a => a.Descricao.ToLower().Contains(search))
                .ToListAsync();

            return View(projetos);
        }

        public IActionResult Admin()
        {
            return RedirectToAction("Login","Account");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
