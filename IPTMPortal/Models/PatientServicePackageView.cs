using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IPTMPortal.Models
{   [Keyless]
    public class PatientServicePackageView
    {   
        public string Ailment { get; set; }
        [Key]
        public string PackageName { get; set; }
        public string TestDetails { get; set; }
        public double Cost { get; set; }
        public int Duration { get; set; }

        public PatientServicePackageView()
        { }
    }
}
