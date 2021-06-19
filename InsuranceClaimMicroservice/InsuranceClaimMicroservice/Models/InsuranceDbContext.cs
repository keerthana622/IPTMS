using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceClaimMicroservice.Models
{
    public class InsuranceDbContext : DbContext
    {
        public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options) : base(options) { }
        public DbSet<Insurer> Insurers { get; set; }
        public DbSet<InsuranceClaim> Claims { get; set; }
    }
}
