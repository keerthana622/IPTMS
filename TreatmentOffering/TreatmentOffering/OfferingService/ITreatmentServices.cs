using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatmentOffering.Models;

namespace TreatmentOffering.OfferingService
{
    public interface ITreatmentServices
    {
        List<PatientServicePackageView> GetPackages();
        List<PatientServicePackageView> GetPackagesByName(string packageName);
        List<SpecialistView> GetSpecialistDetails();
    }
}
