using IPTMAdminPortal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using IPTMAdminPortal.Repository;
using IPTMAdminPortal.Models;

namespace IPTMAdminPortal.Service
{
    public class GetClaimCost : IClaim
    {
        public int ClaimCost(Claim claim)
        {
            string cost;
            string apiBaseUrl = "https://localhost:44383/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseUrl);

                var responseTask = client.GetAsync("api/InsuranceClaim/initiateClaim?patientName=" + claim.PatientName +
                    "&ailmentName=" + claim.AilmentName + "&packageName=" + claim.PackageName + "&insurername=" + claim.InsurerName);

                responseTask.Wait();

                var result = responseTask.Result;

                var readData = result.Content.ReadAsStringAsync();
                readData.Wait();
                cost = readData.Result;

            }
            try
            {
                return Int16.Parse(cost);
            }
            catch
            {
                return 1000; // default
            }
        }
    }
}
