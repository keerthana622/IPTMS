using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreatmentMicroservice.Models
{
    public class TreatmentContext : DbContext
    {
        public TreatmentContext(DbContextOptions<TreatmentContext> options) : base(options) { }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<TreatmentPlan> Plans { get; set; }
    }
}
