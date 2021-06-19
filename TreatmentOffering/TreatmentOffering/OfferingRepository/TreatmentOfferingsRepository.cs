using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TreatmentOffering.Models;

namespace TreatmentOffering.OfferingRepository
{
    public class TreatmentOfferingsRepository : IOfferingServices
    {
        Offerings offerings = new Offerings();
        public List<Ailment> Ailments { get { return offerings.ailmentCategory; } }
        public List<TreatmentPackage> Packages { get { return offerings.packages; } }
        public List<Specialist> Specialists { get { return offerings.specialistsList; } }        
        public List<PatientServicePackageView> AllPackage()
        {
            List<PatientServicePackageView> packages = (from x in Ailments
                                                        join y in Packages on x.AilmentId equals y.AilmentId
                                                        select new PatientServicePackageView()
                                                        {
                                                            PackageId = y.PackageId,
                                                            Ailment = x.AilmentName,
                                                            PackageName = y.PackageName,
                                                            TestDetails = y.TestDetails,
                                                            Cost = y.Cost,
                                                            Duration = y.Duration
                                                        }).ToList<PatientServicePackageView>();
            return packages;
        }
        public List<SpecialistView> AllSpecialist()
        {
            List<SpecialistView> specialists = (from x in Specialists 
                                                join y in Ailments on x.AreaOfExpertise equals y.AilmentId 
                                                select new SpecialistView()
                                                {
                                                    SpecialistId = x.Id,
                                                    Name = x.Name,
                                                    Expertise = y.AilmentName,
                                                    YearsOfExp = x.YearsOfExp,
                                                    Contact = x.Contact
                                                }).ToList<SpecialistView>();
            return specialists;
        }
    }
}
