using log4net;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TreatmentMicroservice.Models;

namespace TreatmentMicroservice.TreatmentRepository
{
    public class TreatmentRepo : ITreatmentRepo
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private TreatmentContext _context;
        private HttpClient _client;
        private HttpResponseMessage _response;
        public TreatmentRepo(TreatmentContext context)
        {
            this._context = context;
            _client = new HttpClient();
            _client.BaseAddress = new Uri(@"https://localhost:44395/");            
        }
        public async Task<List<PatientServicePackage>> GetPackageList()
        {
            log.Info("Pateinsts Package List from Offering Microservice is being invoked");
            List<PatientServicePackage> packageList;
            _response = new HttpResponseMessage();
            _response = _client.GetAsync("api/offering/getPackages").Result;
            string apiResponse = await _response.Content.ReadAsStringAsync();
            packageList = JsonConvert.DeserializeObject<List<PatientServicePackage>>(apiResponse);
            return packageList;
        }
        public async Task<List<SpecialistView>> GetSpecialists()
        {
            log.Info("Pateinsts Specialist List from Offering Microservice is being invoked");
            List<SpecialistView> specialists;
            _response = new HttpResponseMessage();
            _response = _client.GetAsync("api/offering/getSpecialists").Result;
            string apiResponse = await _response.Content.ReadAsStringAsync();
            specialists = JsonConvert.DeserializeObject<List<SpecialistView>>(apiResponse);
            return specialists;
        }
        public async Task<bool> SaveAll(Patient patientDetails, TreatmentPlan plan)
        {
            log.Info("Patient details along with plan is being saved");
            try
            {
                _context.Patients.Add(patientDetails);
                _context.Plans.Add(plan);
                await Task.Run(() => _context.SaveChanges());
                return true;
            }
            catch (Exception ex)
            {
                log.Error("There is no patient details available"+ex.Message);
                return false;
            }
        }
        public async Task<TreatmentPlan> GeneratePlan(Patient patientDetails)
        {
            int patientCount = (from x in _context.Patients select x).Count();
            patientDetails.Id = ++patientCount;            

            //Receiving package and specialist lists            
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "tokenNo");            
            List<PatientServicePackage> packageList = await GetPackageList();            
            List<SpecialistView> specialistList = await GetSpecialists();

            TreatmentPlan plan = null;
            if (packageList!=null && specialistList!=null)
            {
                PatientServicePackage package = (from x in packageList where x.PackageName == patientDetails.PackageName
                                                && x.Ailment == patientDetails.Ailment select x).SingleOrDefault<PatientServicePackage>();
                SpecialistView specialist;
                if (patientDetails.PackageName == "Special")
                {
                    specialist = (from x in specialistList where x.Expertise == patientDetails.Ailment
                                    && x.YearsOfExp >= 8 select x).SingleOrDefault<SpecialistView>();
                }
                else
                {
                    specialist = (from x in specialistList where x.Expertise == patientDetails.Ailment
                                    && x.YearsOfExp < 8 select x).SingleOrDefault<SpecialistView>();
                }
                int plansCount = (from x in _context.Plans select x).Count();
                plan = new TreatmentPlan()
                {
                    PlanId = ++plansCount,
                    Patient = patientDetails,
                    PatientId = patientDetails.Id,
                    AilmentName = patientDetails.Ailment,
                    PackageName = package.PackageName,
                    TestDetails = package.TestDetails,
                    Cost = package.Cost * (package.Duration * 7),
                    SpecialistName = specialist.Name,
                    TreatmentCommencementDate = DateTime.Parse(patientDetails.CommencementDate),
                    TreatmentEndDate = DateTime.Parse(patientDetails.CommencementDate).AddDays(package.Duration * 7)
                };                                
            }
            if (!await SaveAll(patientDetails, plan))
            {
                plan = null;
            }
            return plan;
        }        
    }
}
