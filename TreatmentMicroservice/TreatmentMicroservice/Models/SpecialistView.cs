using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreatmentMicroservice.Models
{
    public class SpecialistView
    {
        public int SpecialistId { get; set; }
        public string Name { get; set; }
        public string Expertise { get; set; }
        public int YearsOfExp { get; set; }
        public long Contact { get; set; }
    }
}
