using InsuranceClaimMicroservice.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using log4net;

namespace InsuranceClaimMicroservice.InsuranceRepository
{
    public class InsuranceClaimRepository : IInsuranceClaim
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string _connectionString;
        private string _query;
        private InsuranceDbContext _context;        
        public InsuranceClaimRepository(InsuranceDbContext context)
        {
            this._context = context;
            this._connectionString = @"Server=LAPTOP-EOF4A94R;Database=TreatmentDB;Trusted_Connection=True;MultipleActiveResultSets=True";
            this._query = @"select PatientId, y.PlanId, x.Name, y.PackageName, y.SpecialistName, y.AilmentName, y.Cost, y.TreatmentCommencementDate, y.TreatmentEndDate from Patients x join Plans y on x.Id=y.PatientId";
        }        
        public List<Insurer> GetInsurerList()
        {
            return (from x in _context.Insurers select x).ToList<Insurer>();            
        }
        public async Task<List<TreatmentPlan>> GetPlansList()
        {
            List<TreatmentPlan> planList = new List<TreatmentPlan>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(_query, con))
            {
                SqlDataReader reader = null;
                try
                {
                    log.Info("Patients plan details are being invoked");
                    con.Open();
                    reader = await Task.Run(() => cmd.ExecuteReader(CommandBehavior.CloseConnection));
                }
                catch (Exception ex)
                {
                    log.Error("Planlist is Null"+ ex.Message);
                    planList = null;
                }
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        planList.Add(
                            new TreatmentPlan
                            {
                                PlanId = int.Parse(reader[1].ToString()),
                                PatientId = int.Parse(reader[0].ToString()),
                                PatientName = reader[2].ToString(),
                                PackageName = reader[3].ToString(),
                                SpecialistName = reader[4].ToString(),
                                AilmentName = reader[5].ToString(),
                                Cost = double.Parse(reader[6].ToString()),
                                TreatmentCommencementDate = DateTime.Parse(reader[7].ToString()),
                                TreatmentEndDate = DateTime.Parse(reader[8].ToString())
                            });
                    }
                }
                else
                {
                    planList = null;
                }
            }
            return planList;
        }
        public async Task<double> InitiateClaim(string patientName, string ailmentName, string packageName, string insurerName)
        {
            List<TreatmentPlan> planList = await GetPlansList();            
            double balance = 0;
            if (planList.Count != 0)
            {
                TreatmentPlan plan = (from x in planList where x.PatientName == patientName
                                      && x.PackageName==packageName && x.AilmentName == ailmentName
                                      select x).SingleOrDefault<TreatmentPlan>();               

                if (plan != null)
                {
                    Insurer insurer = (from x in _context.Insurers where x.InsurerName == insurerName
                                       && x.InsurerPackageName.Contains(packageName) select x).SingleOrDefault<Insurer>();
                    int claimsCount = (from x in _context.Claims select x).Count();
                    balance = (plan.Cost) - insurer.AmountLimit;
                    InsuranceClaim claimDetails = new InsuranceClaim()
                    {
                        ClaimId = ++claimsCount,
                        PlanId = plan.PlanId,
                        PatientName = plan.PatientName,
                        AilmentName = plan.AilmentName,
                        PackageName = plan.PackageName,
                        Insurer = insurer,
                        InsurerId = insurer.InsurerId,
                        InsurerName = insurer.InsurerName,
                        PaybleBalance = balance
                    };
                    _context.Claims.Add(claimDetails);
                    _context.SaveChanges();
                }                                
            }
            else
            {
                balance = -1;
            }
            return balance;
        }       
    }
}
