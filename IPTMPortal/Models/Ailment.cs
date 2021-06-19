using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IPTMPortal.Models
{
    public class Ailment
    {
        [Key]
        public int AilmentId { get; set; }
        public string AilmentName { get; set; }
    }
}
