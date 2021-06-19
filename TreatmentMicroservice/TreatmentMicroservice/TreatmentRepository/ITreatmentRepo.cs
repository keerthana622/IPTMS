using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatmentMicroservice.Models;

namespace TreatmentMicroservice.TreatmentRepository
{
    public interface ITreatmentRepo
    {
        Task<List<PatientServicePackage>> GetPackageList();
        Task<List<SpecialistView>> GetSpecialists();
        Task<bool> SaveAll(Patient patientDetails, TreatmentPlan plan);
        Task<TreatmentPlan> GeneratePlan(Patient patientDetails);
    }
}
