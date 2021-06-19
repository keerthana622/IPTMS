using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IPTMAdminPortal.Models
{
    public class Insurer
    {

        [Key]
        public int InsurerId { get; set; }
        public string InsurerName { get; set; }
       
        public string InsurerPackageName { get; set; }
        public long AmountLimit { get; set; }
        public int DisbursementDuration { get; set; }

        public Insurer()
        { }

        public Insurer(string insurerName, string insurerPackageName, long amountLimit, int disbursementDuration)
        {
            InsurerName = insurerName;
            InsurerPackageName = insurerPackageName;
            AmountLimit = amountLimit;
            DisbursementDuration = disbursementDuration;
        }
    }
}
