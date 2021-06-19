using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TreatmentOffering.Models
{
    public class PatientServicePackageView
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PackageId { get; set; }
        public string Ailment { get; set; }
        public string PackageName { get; set; }
        public string TestDetails { get; set; }
        public double Cost { get; set; }
        public int Duration { get; set; }
    }
}
