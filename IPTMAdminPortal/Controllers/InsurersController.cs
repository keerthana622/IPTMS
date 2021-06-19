using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IPTMAdminPortal.Data;
using IPTMAdminPortal.Models;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;

namespace IPTMAdminPortal.Controllers
{   [Authorize]
    public class InsurersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InsurersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Insurers
        
        public async Task<IActionResult> Index()
        {

            return View(await _context.Insurer.ToListAsync());
        }

        // GET: Insurers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insurer = await _context.Insurer
                .FirstOrDefaultAsync(m => m.InsurerId == id);
            if (insurer == null)
            {
                return NotFound();
            }

            return View(insurer);
        }

        // GET: Insurers/Create
        public IActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InsurerId,InsurerName,InsurerPackageName,AmountLimit,DisbursementDuration")] Insurer insurer)
        {
            
            if (ModelState.IsValid)
            {
                _context.Add(insurer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(insurer);
        }

        // GET: Insurers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insurer = await _context.Insurer.FindAsync(id);
            if (insurer == null)
            {
                return NotFound();
            }
            return View(insurer);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InsurerId,InsurerName,InsurerPackageName,AmountLimit,DisbursementDuration")] Insurer insurer)
        {
            if (id != insurer.InsurerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insurer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsurerExists(insurer.InsurerId))
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
            return View(insurer);
        }

      
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insurer = await _context.Insurer
                .FirstOrDefaultAsync(m => m.InsurerId == id);
            if (insurer == null)
            {
                return NotFound();
            }

            return View(insurer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var insurer = await _context.Insurer.FindAsync(id);
            _context.Insurer.Remove(insurer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsurerExists(int id)
        {
            return _context.Insurer.Any(e => e.InsurerId == id);
        }
    }
}
