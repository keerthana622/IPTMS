using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using TreatmentOffering.Models;
using TreatmentOffering.OfferingRepository;

namespace TreatmentOffering.OfferingService
{
    public class TreatmentServices : ITreatmentServices
    {

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IOfferingServices _repo;
        public TreatmentServices(IOfferingServices repo)
        {
            this._repo = repo;
        }
        public List<PatientServicePackageView> GetPackages()
        {            
            try
            {
                log.Info("Getting packages..");
                List<PatientServicePackageView> package = _repo.AllPackage();
                if (package.Count == 0)
                {
                    log.Error("No package found");
                    return null;
                }
                log.Info("Package list returned.");
                return package;
            }
            catch (Exception ex)
            {

                log.Error($"Some error occurred while fetching package!\n {ex.Message}");
                return null;
            }            
        }
        public List<PatientServicePackageView> GetPackagesByName(string packageName)
        {
            try
            {
                log.Info($"Getting {packageName} packages..");
                List<PatientServicePackageView> package = _repo.AllPackage();
                if (package.Count == 0)
                {
                    log.Error($"{package} package not found!");
                    return null;
                }
                log.Info($"{packageName} package list returned.");
                return package.Where(p => p.PackageName==packageName).ToList<PatientServicePackageView>();
            }
            catch (Exception ex)
            {
                log.Error($"Some error occurred while fetching {packageName} package!\n {ex.Message}");
                return null;
            }
        }
        public List<SpecialistView> GetSpecialistDetails()
        {
            try
            {
                log.Info("Getting specialists..");
                List<SpecialistView> specialists = _repo.AllSpecialist();
                if (specialists.Count == 0)
                {
                    log.Error($"Operation failed while fetching specialist details!");
                    return null;
                }
                log.Info("Specialists list found and returned.");
                return specialists;
            }
            catch (Exception ex)
            {
                log.Error($"Some error occurred while fetching specialist list!\n {ex.Message}");
                return null;
            }
        }
    }
}
