using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IPTMPortal.Data;
using IPTMPortal.Models;
using Microsoft.AspNetCore.Authorization;

namespace IPTMPortal.Controllers
{
   
    public class TreatmentPlansController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TreatmentPlansController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TreatmentPlan.Include(t => t.Patient);
            return View(await applicationDbContext.ToListAsync());
        }

       
       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treatmentPlan = await _context.TreatmentPlan
                .Include(t => t.Patient)
                .FirstOrDefaultAsync(m => m.PlanId == id);
            if (treatmentPlan == null)
            {
                return NotFound();
            }

            return View(treatmentPlan);
        }

        // GET: TreatmentPlans/Create
        public IActionResult Create()
        {
            ViewData["PatientId"] = new SelectList(_context.Set<Patient>(), "Id", "Id");
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlanId,PatientId,AilmentName,PackageName,TestDetails,Cost,SpecialistName,TreatmentCommencementDate,TreatmentEndDate")] TreatmentPlan treatmentPlan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(treatmentPlan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PatientId"] = new SelectList(_context.Set<Patient>(), "Id", "Id", treatmentPlan.PatientId);
            // return View(treatmentPlan);
           return RedirectToAction("Details");
        }

        // GET: TreatmentPlans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treatmentPlan = await _context.TreatmentPlan.FindAsync(id);
            if (treatmentPlan == null)
            {
                return NotFound();
            }
            ViewData["PatientId"] = new SelectList(_context.Set<Patient>(), "Id", "Id", treatmentPlan.PatientId);
            return View(treatmentPlan);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, 
        [Bind("PlanId,PatientId,AilmentName,PackageName,TestDetails,Cost,SpecialistName,TreatmentCommencementDate,TreatmentEndDate")] TreatmentPlan treatmentPlan)
        {
            if (id != treatmentPlan.PlanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(treatmentPlan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TreatmentPlanExists(treatmentPlan.PlanId))
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
            ViewData["PatientId"] = new SelectList(_context.Set<Patient>(), "Id", "Id", treatmentPlan.PatientId);
            return View(treatmentPlan);
        }

        // GET: TreatmentPlans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treatmentPlan = await _context.TreatmentPlan
                .Include(t => t.Patient)
                .FirstOrDefaultAsync(m => m.PlanId == id);
            if (treatmentPlan == null)
            {
                return NotFound();
            }

            return View(treatmentPlan);
        }

        // POST: TreatmentPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var treatmentPlan = await _context.TreatmentPlan.FindAsync(id);
            _context.TreatmentPlan.Remove(treatmentPlan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TreatmentPlanExists(int id)
        {
            return _context.TreatmentPlan.Any(e => e.PlanId == id);
        }
    }
}
