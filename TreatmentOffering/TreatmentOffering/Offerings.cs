using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatmentOffering.Models;

namespace TreatmentOffering
{
    public class Offerings
    {        
        public List<Ailment> ailmentCategory = new List<Ailment>()
        {
            new Ailment {AilmentId = 1, AilmentName = "Orthopedics"},
            new Ailment {AilmentId = 2, AilmentName = "Urology"}
        };
        public List<TreatmentPackage> packages = new List<TreatmentPackage>()
        {
            new TreatmentPackage { PackageId = 1, AilmentId = 1, PackageName = "Basic", TestDetails="OPT1, OPT2", Cost = 2500, Duration = 4},
            new TreatmentPackage { PackageId = 2, AilmentId = 1, PackageName = "Special", TestDetails="OPT3, OPT4", Cost = 3000, Duration = 6},
            new TreatmentPackage { PackageId = 3, AilmentId = 2, PackageName = "Basic", TestDetails="UPT1, UPT2", Cost = 4000, Duration = 4},
            new TreatmentPackage { PackageId = 4, AilmentId = 2, PackageName = "Special", TestDetails="UPT3, UPT4", Cost = 5000, Duration = 6}
        };
        public List<Specialist> specialistsList = new List<Specialist>()
        {
            new Specialist {Id = 1, Name = "John Doe", AreaOfExpertise = 1, YearsOfExp = 10, Contact = 9845673451},
            new Specialist {Id = 2, Name = "Prashant Hegde", AreaOfExpertise = 1, YearsOfExp = 4, Contact = 8055673452},
            new Specialist {Id = 3, Name = "Jane Doe", AreaOfExpertise = 2, YearsOfExp = 12, Contact = 9067872211},
            new Specialist {Id = 4, Name = "Amit Jana", AreaOfExpertise = 2, YearsOfExp = 4, Contact = 8900453498}
        };
    }
}
