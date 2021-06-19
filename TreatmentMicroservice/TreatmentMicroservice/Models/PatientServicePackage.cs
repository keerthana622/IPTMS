using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreatmentMicroservice.Models
{
    public class PatientServicePackage
    {
        public int PackageId { get; set; }
        public string Ailment { get; set; }
        public string PackageName { get; set; }
        public string TestDetails { get; set; }
        public double Cost { get; set; }
        public int Duration { get; set; }
    }
}
