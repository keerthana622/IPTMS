using InsuranceClaimMicroservice.Models;
using InsuranceClaimMicroservice.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceClaimMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceClaimController : ControllerBase
    {
        private IClaimService _service;
        public InsuranceClaimController(IClaimService service)
        {
            this._service = service;
        }
        [HttpGet]
        [Route("getInsurerDetail")]
        public IEnumerable<Insurer> GetInsurerDetails()
        {
            return _service.GetAllInsurer();
        }

        [HttpGet]
        [Route("getInsurerByPackage")]
        public IEnumerable<Insurer> GetInsurerDtailsByPackage([FromQuery] string packageName)
        {
            return _service.GetAllInsurerByPackage(packageName);
        }

        [HttpPost]
        [Route("initiateClaim")]
        public async Task<double> InitiateClaimRequest([FromQuery]string patientName, [FromQuery] string ailmentName, [FromQuery] string packageName, [FromQuery] string insurerName)
        {
            return await Task.Run(() => _service.GetBalancePayble(patientName, ailmentName, packageName, insurerName));
        }
    }
}
