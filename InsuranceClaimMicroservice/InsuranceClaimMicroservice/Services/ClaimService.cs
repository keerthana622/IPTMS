using InsuranceClaimMicroservice.InsuranceRepository;
using InsuranceClaimMicroservice.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceClaimMicroservice.Services
{
    public class ClaimService : IClaimService
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IInsuranceClaim _repo;
        public ClaimService(IInsuranceClaim repo)
        {
            this._repo = repo;
        }
        public List<Insurer> GetAllInsurer()
        {
            try
            {
                log.Info("Getting Insurer Details..");
                List<Insurer> insurerList = _repo.GetInsurerList();
                if (insurerList.Count == 0)
                {
                    log.Info("Oops internal error! Couldn't find any Insurer Details.");
                    return null;
                }
                log.Info("Insurer lists returned.");
                return insurerList;
            }
            catch (Exception ex)
            {
                log.Error($"Some error occurred while fetching the details!\n {ex.Message}");
                return null;
            }
        }
        public List<Insurer> GetAllInsurerByPackage(string packagename)
        {
            try
            {
                log.Info($"Getting Insurer details serving {packagename} package");
                List<Insurer> insurerList = _repo.GetInsurerList();
                if (insurerList.Count == 0)
                {
                    log.Info("Oops internal error! Couldn't find any Insurer Details.");
                    return null;
                }
                log.Info("Insurer lists returned.");
                return insurerList.Where(x => x.InsurerPackageName.Contains(packagename)).ToList<Insurer>();
            }
            catch (Exception ex)
            {
                log.Error($"Some error occurred while fetching the details!\n {ex.Message}");
                return null;
            }
        }
        public async Task<double> GetBalancePayble(string patientName, string ailment, string packageName, string insurer)
        {
            double balacePayble = await _repo.InitiateClaim(patientName, ailment, packageName, insurer);
            if (balacePayble == -1)
            {
                log.Error($"Some error occurred while fetching getting plan lists!");
            }
            return balacePayble;
        }
    }
}
