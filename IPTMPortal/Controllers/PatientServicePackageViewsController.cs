using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IPTMPortal.Data;
using IPTMPortal.Models;
using Microsoft.AspNetCore.Authorization;

namespace IPTMPortal.Controllers
{
    public class PatientServicePackageViewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientServicePackageViewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
           
            return View(await _context.PatientServicePackageView.ToListAsync());
        }

        // GET: PatientServicePackageViews/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientServicePackageView = await _context.PatientServicePackageView
                .FirstOrDefaultAsync(m => m.PackageName == id);
            if (patientServicePackageView == null)
            {
                return NotFound();
            }

            return View(patientServicePackageView);
        }

        // GET: PatientServicePackageViews/Create
        public IActionResult Create()
        {
            return View();
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ailment,PackageName,TestDetails,Cost,Duration")] PatientServicePackageView patientServicePackageView)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patientServicePackageView);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patientServicePackageView);
        }

        // GET: PatientServicePackageViews/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientServicePackageView = await _context.PatientServicePackageView.FindAsync(id);
            if (patientServicePackageView == null)
            {
                return NotFound();
            }
            return View(patientServicePackageView);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Ailment,PackageName,TestDetails,Cost,Duration")] PatientServicePackageView patientServicePackageView)
        {
            if (id != patientServicePackageView.PackageName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patientServicePackageView);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientServicePackageViewExists(patientServicePackageView.PackageName))
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
            return View(patientServicePackageView);
        }

        // GET: PatientServicePackageViews/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientServicePackageView = await _context.PatientServicePackageView
                .FirstOrDefaultAsync(m => m.PackageName == id);
            if (patientServicePackageView == null)
            {
                return NotFound();
            }

            return View(patientServicePackageView);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var patientServicePackageView = await _context.PatientServicePackageView.FindAsync(id);
            _context.PatientServicePackageView.Remove(patientServicePackageView);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientServicePackageViewExists(string id)
        {
            return _context.PatientServicePackageView.Any(e => e.PackageName == id);
        }
    }
}
