using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatmentOffering.Models;
using TreatmentOffering.OfferingRepository;
using TreatmentOffering.OfferingService;

namespace TreatmentOffering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferingController : ControllerBase
    {
        private ITreatmentServices _services;
        public OfferingController(ITreatmentServices services)
        {
            this._services = services;
        }
        [HttpGet]
        [Route("getPackages")]
        public IEnumerable<PatientServicePackageView> GetTreatmentPackages()
        {
            return _services.GetPackages();
        }

        [HttpGet]
        [Route("getPackagesByName")]
        public IEnumerable<PatientServicePackageView> GetTreatmentPackagesByName([FromQuery] string packageName)
        {
            return _services.GetPackagesByName(packageName);
        }

        [HttpGet]
        [Route("getSpecialists")]
        public IEnumerable<SpecialistView> GetSpecialist()
        {
            return _services.GetSpecialistDetails();
        }
    }
}
