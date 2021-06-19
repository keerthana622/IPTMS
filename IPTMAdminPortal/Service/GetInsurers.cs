using IPTMAdminPortal.Data;
using IPTMAdminPortal.Models;
using IPTMAdminPortal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IPTMAdminPortal.Service
{
    public class GetInsurers : IInsurer
    {
        private readonly ApplicationDbContext _context;

        public GetInsurers(ApplicationDbContext context)
        {
            _context = context;
        }
        public void GetInsurer()
        {
            string apiBaseUrl = "https://localhost:44383/";
            IList<Insurer> packagedetails = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseUrl);
                var responseTask = client.GetAsync("api/InsuranceClaim/getInsurerDetail");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readData = result.Content.ReadAsAsync<IList<Insurer>>();
                    readData.Wait();
                    packagedetails = readData.Result;
                }
            }

            try
            {
                foreach (var pkg in packagedetails)
                {
                    if (_context.Insurer.Where(j => j.InsurerPackageName == pkg.InsurerPackageName).FirstOrDefault() == null)
                    {
                        _context.Insurer.Add(new Insurer(pkg.InsurerName, pkg.InsurerPackageName, pkg.AmountLimit, pkg.DisbursementDuration));
                        _context.SaveChanges();
                    }
                }

            }
            catch
            {

            }
        }
    }
}
