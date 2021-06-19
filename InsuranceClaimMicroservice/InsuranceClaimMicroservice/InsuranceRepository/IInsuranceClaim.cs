using InsuranceClaimMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceClaimMicroservice.InsuranceRepository
{
    public interface IInsuranceClaim
    {
        List<Insurer> GetInsurerList();
        Task<double> InitiateClaim(string patientName, string ailment, string packageName, string insurer);
    }
}
