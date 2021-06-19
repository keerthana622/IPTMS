using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TreatmentMicroservice.Models
{
    public class TreatmentPlan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PlanId { get; set; }
        public Patient Patient { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public string AilmentName { get; set; }
        public string PackageName { get; set; }
        public string TestDetails { get; set; }
        public double Cost { get; set; }
        public string SpecialistName { get; set; }
        public DateTime TreatmentCommencementDate { get; set; }
        public DateTime TreatmentEndDate { get; set; }
    }
}
