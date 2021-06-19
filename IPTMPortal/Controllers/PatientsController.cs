using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IPTMPortal.Data;
using IPTMPortal.Models;
using Microsoft.AspNetCore.Identity;
using System.Text.RegularExpressions;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using IPTMPortal.Service;

namespace IPTMPortal.Controllers
{  
    public class PatientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientsController(ApplicationDbContext context)
        {
            _context = context;

        }
        [Authorize]
        // GET: Patients
        public async Task<IActionResult> Index()
        {
            return View(await _context.Patient.ToListAsync());
        }

        // GET: Patients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patient
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // GET: Patients/Create
        public IActionResult Create()
        {
            PopulatePackages();
            PopulateAilment();
                return View();
        }

        public IActionResult Plan()
        {
            string u = Convert.ToString(Regex.Match(User.Identity.Name, @"^.*?(?=@)").Value);
            var x = _context.TreatmentPlan.Where(x=>x.Patient.Name==u).FirstOrDefault();
            if (x==null)
            {
               return  RedirectToAction("Create");
            }
            else
                return RedirectToAction("Details", "TreatmentPlans", new { id = x.PlanId });


        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Age,Ailment,PackageName,CommencementDate")] Patient patient)
        {
            string u = Convert.ToString(Regex.Match(User.Identity.Name, @"^.*?(?=@)").Value);

            if (_context.Patient.Where(x=>x.Name==patient.Name)==null)
            {
                _context.Add(patient);
                await _context.SaveChangesAsync();
            }
            new GetPatient(_context).CreatePlan(patient);

              var x = _context.TreatmentPlan.Where(x => x.Patient.Name == u).FirstOrDefault();

               return RedirectToAction("Details", "TreatmentPlans", new {id=x.PlanId });

            //return RedirectToAction("Plan");
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patient.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age,Ailment,PackageName,CommencementDate")] Patient patient)
        {
            if (id != patient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(patient.Id))
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
            return View(patient);
        }

        // GET: Patients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patient
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }
        private  void PopulatePackages()
        {
            var pkg =  _context.PatientServicePackageView.OrderBy(x=>x.PackageName).ToList();
            ViewBag.pkg = pkg;
        }
        private void PopulateAilment()
        {
            var ail = _context.PatientServicePackageView.OrderBy(x => x.Ailment).ToList();
            ViewBag.ail = ail;
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patient = await _context.Patient.FindAsync(id);
            _context.Patient.Remove(patient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientExists(int id)
        {
            return _context.Patient.Any(e => e.Id == id);
        }
    }
}
