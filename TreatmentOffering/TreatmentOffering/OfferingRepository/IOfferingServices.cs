using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatmentOffering.Models;

namespace TreatmentOffering.OfferingRepository
{
    public interface IOfferingServices
    {
        List<PatientServicePackageView> AllPackage();
        List<SpecialistView> AllSpecialist();
    }
}
