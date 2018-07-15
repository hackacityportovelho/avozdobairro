using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ComCity.Data;
using ComCity.Models;

namespace ComCity.Controllers
{
    public class FeedbacksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FeedbacksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Feedbacks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Feedbacks.ToListAsync());
        }

        // GET: Feedbacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedback = await _context.Feedbacks
                .SingleOrDefaultAsync(m => m.Id == id);
            if (feedback == null)
            {
                return NotFound();
            }

            return View(feedback);
        }

        public async Task<IActionResult> Sim(int EnqueteId)
        {
            var Enquete = await _context.Enquetes.SingleOrDefaultAsync(a => a.Id == EnqueteId);
            ViewBag.Enquete = Enquete;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Sim(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                feedback.Aprovado = true;
                _context.Add(feedback);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var Enquete = await _context.Enquetes.SingleOrDefaultAsync(a => a.Id == feedback.EnqueteId);
            ViewBag.Enquete = Enquete;

            return View(feedback);
        }

        public async Task<IActionResult> Nao(int EnqueteId)
        {
            var Enquete = await _context.Enquetes.SingleOrDefaultAsync(a => a.Id == EnqueteId);
            ViewBag.Enquete = Enquete;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Nao(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                feedback.Aprovado = false;
                _context.Add(feedback);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var Enquete = await _context.Enquetes.SingleOrDefaultAsync(a => a.Id == feedback.EnqueteId);
            ViewBag.Enquete = Enquete;

            return View(feedback);
        }
    }
}
