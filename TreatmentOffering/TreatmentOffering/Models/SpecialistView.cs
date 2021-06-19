using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TreatmentOffering.Models
{
    public class SpecialistView
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SpecialistId { get; set; }
        public string Name { get; set; }
        public string Expertise { get; set; }
        public int YearsOfExp { get; set; }
        public long Contact { get; set; }
    }
}
