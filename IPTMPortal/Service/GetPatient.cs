using IPTMPortal.Data;
using IPTMPortal.Models;
using IPTMPortal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IPTMPortal.Service
{
    public class GetPatient : IPatient
    {
        ApplicationDbContext _context;
        public GetPatient(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CreatePlan(Patient patient)
        {
            string apiBaseUrl = "https://localhost:44391/";
           
            TreatmentPlan plandetails = null;
           
                using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseUrl);

                var responseTask = client.GetAsync("api/Treatment/getPlan?Name=" + patient.Name + "&Age=" + patient.Age + "&Ailment="
                         + patient.Ailment + "&PackageName=" + patient.PackageName + "&CommencementDate=" + patient.CommencementDate);

                responseTask.Wait();

                var result = responseTask.Result;

                var readData = result.Content.ReadAsAsync<TreatmentPlan>();
                readData.Wait();
                plandetails = readData.Result;

            }
           // try
            {
                _context.TreatmentPlan.Add(plandetails);
                _context.SaveChanges();
            }
          //  catch
            {

            }
          
        }

       
       
    }
}
