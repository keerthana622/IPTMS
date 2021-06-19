using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatmentMicroservice.Models;
using TreatmentMicroservice.Services;
using TreatmentMicroservice.TreatmentRepository;

namespace TreatmentMicroservice.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentController : ControllerBase
    {
        private IServices _services;
        public TreatmentController(IServices services)
        {
            this._services = services;
        }
        [HttpGet]
        [Route("getPlan")]
        public async Task<TreatmentPlan> GetTreatmentPlan([FromQuery] Patient patientDetails)
        {
            return await Task.Run(()=> _services.GeneratePlanDetails(patientDetails));
        } 
    }
}
