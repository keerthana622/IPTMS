using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TreatmentOffering.Models
{
    public class Ailment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AilmentId { get; set; }
        public string AilmentName { get; set; }
    }
}
