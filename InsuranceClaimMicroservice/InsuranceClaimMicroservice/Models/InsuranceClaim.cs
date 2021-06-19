using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceClaimMicroservice.Models
{
    public class InsuranceClaim
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClaimId { get; set; }
        public int PlanId { get; set; }
        public string PatientName { get; set; }
        public string AilmentName { get; set; }
        public string PackageName { get; set; }
        public Insurer Insurer { get; set; }
        [ForeignKey("Insurer")]
        public int InsurerId { get; set; }
        public string InsurerName { get; set; }
        public double PaybleBalance { get; set; }
    }
}
