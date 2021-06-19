using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using IPTMPortal.Models;
using TreatmentOffering.Models;

namespace IPTMPortal.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<IPTMPortal.Models.TreatmentPackage> TreatmentPackage { get; set; }
        public DbSet<IPTMPortal.Models.PatientServicePackageView> PatientServicePackageView { get; set; }
        public DbSet<TreatmentOffering.Models.SpecialistView> SpecialistView { get; set; }
        public DbSet<IPTMPortal.Models.TreatmentPlan> TreatmentPlan { get; set; }
        public DbSet<IPTMPortal.Models.Patient> Patient { get; set; }
       

    }
}
