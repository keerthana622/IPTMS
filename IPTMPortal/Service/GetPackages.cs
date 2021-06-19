using IPTMPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using IPTMPortal.Repository;
using IPTMPortal.Data;
using log4net;

namespace IPTMPortal.Service
{
    public class GetPackages : ITreatmentPackage
    {
        private readonly ApplicationDbContext _context;

        public GetPackages(ApplicationDbContext context)
        {
            _context = context;
        }
        ILog log = LogManager.GetLogger("mylog");
        void ITreatmentPackage.GetPackages()
        {
            string apiBaseUrl = "https://localhost:44395/";
            IList<PatientServicePackageView> packagedetails = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseUrl);
                var responseTask = client.GetAsync("/api/offering/getPackages");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readData = result.Content.ReadAsAsync<IList<PatientServicePackageView>>();
                    readData.Wait();
                    packagedetails = readData.Result;
                }
            }
            try
            {
               
                foreach (var pkg in packagedetails)
                {
                    _context.PatientServicePackageView.Add(pkg);
                    _context.SaveChanges();
                }

            }
            catch(Exception e)
            {
                log.Error("ERROR",e);
            }

        }
    }
}
