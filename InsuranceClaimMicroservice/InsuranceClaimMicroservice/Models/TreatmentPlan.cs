using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceClaimMicroservice.Models
{
    public class TreatmentPlan
    {
        [Key]
        public int PlanId { get; set; }        
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string PackageName { get; set; }
        public string SpecialistName { get; set; }
        public string AilmentName { get; set; }
        public double Cost { get; set; }        
        public DateTime TreatmentCommencementDate { get; set; }
        public DateTime TreatmentEndDate { get; set; }
    }
}
