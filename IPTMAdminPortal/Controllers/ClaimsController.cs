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
using System.Text.RegularExpressions;
using IPTMAdminPortal.Service;

namespace IPTMAdminPortal.Controllers
{
    public class ClaimsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClaimsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Claims
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Claim.Include(c => c.Insurer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Claims/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claim = await _context.Claim
                .Include(c => c.Insurer)
                .FirstOrDefaultAsync(m => m.ClaimId == id);
            if (claim == null)
            {
                return NotFound();
            }

            return View(claim);
        }
       
        // GET: Claims/Create
        public IActionResult Create()
        {
            PopulateIns();
            ViewBag.Name = TempData["Name"];
            ViewBag.Ailment = TempData["Ailment"];
            ViewBag.pkg = TempData["pkg"];
            ViewBag.Insid = TempData["Insid"];
            ViewBag.InsName = TempData["InsName"];
            ViewBag.bal = TempData["bal"];
            ViewBag.Cost = TempData["Cost"];

            
            ViewData["InsurerId"] = new SelectList(_context.Insurer, "InsurerId", "InsurerId");
           
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClaimId,PlanId,PatientName,AilmentName,PackageName,InsurerId,InsurerName,PaybleBalance")] Claim claim)
        {
            claim.PaybleBalance = new GetClaimCost().ClaimCost(claim);

            if (ModelState.IsValid)
            {
                _context.Claim.Add(claim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InsurerId"] = new SelectList(_context.Insurer, "InsurerId", "InsurerId", claim.InsurerId);

            return View(claim);
        }

        // GET: Claims/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claim = await _context.Claim.FindAsync(id);
            if (claim == null)
            {
                return NotFound();
            }
            ViewData["InsurerId"] = new SelectList(_context.Insurer, "InsurerId", "InsurerId", claim.InsurerId);
            return View(claim);
        }

        // POST: Claims/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClaimId,PlanId,PatientName,AilmentName,PackageName,InsurerId,InsurerName,PaybleBalance")] Claim claim)
        {
            if (id != claim.ClaimId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(claim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClaimExists(claim.ClaimId))
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
            ViewData["InsurerId"] = new SelectList(_context.Insurer, "InsurerId", "InsurerId", claim.InsurerId);
            return View(claim);
        }

        // GET: Claims/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claim = await _context.Claim
                .Include(c => c.Insurer)
                .FirstOrDefaultAsync(m => m.ClaimId == id);
            if (claim == null)
            {
                return NotFound();
            }

            return View(claim);
        }

        // POST: Claims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var claim = await _context.Claim.FindAsync(id);
            _context.Claim.Remove(claim);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private void PopulateIns()
        {
            var Ins = _context.Insurer.OrderBy(x => x.InsurerName).ToList();
            ViewBag.Ins = Ins;
        }

        private bool ClaimExists(int id)
        {
            return _context.Claim.Any(e => e.ClaimId == id);
        }
    }
}
