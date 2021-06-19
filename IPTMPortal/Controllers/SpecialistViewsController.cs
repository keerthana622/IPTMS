using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IPTMPortal.Data;
using TreatmentOffering.Models;
using IPTMPortal.Service;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;

namespace IPTMPortal.Controllers
{  
    public class SpecialistViewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpecialistViewsController(ApplicationDbContext context)
        {
            _context = context;
        }
       

        [Authorize]
        public async Task<IActionResult> Index()
        {
            new GetSpecialist(_context).GetSpecialists();
            return View(await _context.SpecialistView.ToListAsync());
        }

        // GET: SpecialistViews/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialistView = await _context.SpecialistView
                .FirstOrDefaultAsync(m => m.Name == id);
            if (specialistView == null)
            {
                return NotFound();
            }

            return View(specialistView);
        }

        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Expertise,YearsOfExp,Contact")] SpecialistView specialistView)
        {
            if (ModelState.IsValid)
            {
                _context.Add(specialistView);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(specialistView);
        }


        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialistView = await _context.SpecialistView.FindAsync(id);
            if (specialistView == null)
            {
                return NotFound();
            }
            return View(specialistView);
        }


      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Expertise,YearsOfExp,Contact")] SpecialistView specialistView)
        {
            if (id != specialistView.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(specialistView);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecialistViewExists(specialistView.Name))
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
            return View(specialistView);
        }

        // GET: SpecialistViews/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialistView = await _context.SpecialistView
                .FirstOrDefaultAsync(m => m.Name == id);
            if (specialistView == null)
            {
                return NotFound();
            }

            return View(specialistView);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var specialistView = await _context.SpecialistView.FindAsync(id);
            _context.SpecialistView.Remove(specialistView);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecialistViewExists(string id)
        {
            return _context.SpecialistView.Any(e => e.Name == id);
        }
    }
}
