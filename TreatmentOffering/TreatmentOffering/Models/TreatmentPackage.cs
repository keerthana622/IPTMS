using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TreatmentOffering.Models
{
    public class TreatmentPackage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PackageId { get; set; }

        [ForeignKey("Ailment")]
        public int AilmentId { get; set; }
        public string PackageName { get; set; }
        public string TestDetails { get; set; }
        public double Cost { get; set; }
        public int Duration { get; set; }
        public Ailment Ailment { get; set; }
    }
}
