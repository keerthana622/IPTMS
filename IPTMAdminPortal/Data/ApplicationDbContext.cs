using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using IPTMAdminPortal.Models;

namespace IPTMAdminPortal.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<IPTMAdminPortal.Models.Insurer> Insurer { get; set; }
        public DbSet<IPTMAdminPortal.Models.Patient> Patient { get; set; }
        public DbSet<IPTMAdminPortal.Models.Claim> Claim { get; set; }
    }
}
