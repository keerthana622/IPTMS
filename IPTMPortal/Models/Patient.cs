using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TreatmentOffering.Models;

namespace IPTMPortal.Models
{
   
   
    public class Patient
    {
        [Key]
       
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Ailment { get; set; }
        public string PackageName { get; set; }
        public string CommencementDate { get; set; }

        public Patient()
        { }
    }
}
