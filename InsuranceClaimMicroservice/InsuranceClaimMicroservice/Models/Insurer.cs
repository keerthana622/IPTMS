using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceClaimMicroservice.Models
{
    public class Insurer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InsurerId { get; set; }
        public string InsurerName { get; set; }
        public string InsurerPackageName { get; set; }
        public long AmountLimit { get; set; }
        public int DisbursementDuration { get; set; }
    }
}
