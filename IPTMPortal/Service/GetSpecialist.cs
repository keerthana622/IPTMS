using IPTMPortal.Data;
using IPTMPortal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TreatmentOffering.Models;

namespace IPTMPortal.Service
{
    public class GetSpecialist : ISpecialist
    {
        private readonly ApplicationDbContext _context;

        public GetSpecialist(ApplicationDbContext context)
        {
            _context = context;
        }
       
        public string apiBaseUrl = "https://localhost:44395/";

        public void GetSpecialists()
        {
           
                IList<SpecialistView> specialistdetails = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiBaseUrl);
                    var responseTask = client.GetAsync("/api/offering/getSpecialists");
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readData = result.Content.ReadAsAsync<IList<SpecialistView>>();
                        readData.Wait();
                        specialistdetails = readData.Result;
                    }
                }
            
                foreach (var pkg in specialistdetails)
                {
                    _context.SpecialistView.Add(pkg);
                    _context.SaveChanges();
                }

            }
            catch(Exception e)
            {
                
            }


        }
    }
}
