using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using TreatmentMicroservice.Models;
using TreatmentMicroservice.TreatmentRepository;

namespace TreatmentMicroservice.Services
{
    public class TreatmentServices : IServices
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private ITreatmentRepo _repo;
        public TreatmentServices(ITreatmentRepo repo)
        {
            this._repo = repo;
        }
        public async Task<TreatmentPlan> GeneratePlanDetails(Patient patientDetails)
        {
            log.Info("Generating plan...");
            try
            {
                TreatmentPlan plan = await _repo.GeneratePlan(patientDetails);
                if (plan == null)
                {
                    log.Info("Plan generation failed!");
                    return null;
                }
                log.Info("Plan generated and returned.");
                return plan;
            }
            catch (Exception ex)
            {
                log.Error($"Some error occurred while generating plan for {patientDetails.Name}!\n {ex.Message}");
                return null;
            }
        }
    }
}
