using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatmentMicroservice.Models;

namespace TreatmentMicroservice.Services
{
    public interface IServices
    {
        Task<TreatmentPlan> GeneratePlanDetails(Patient patientDetails);
    }
}
