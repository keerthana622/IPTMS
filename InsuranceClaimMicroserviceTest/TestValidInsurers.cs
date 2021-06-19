using System;
using System.Collections.Generic;
using System.Text;
using InsuranceClaimMicroservice.InsuranceRepository;
using InsuranceClaimMicroservice.Models;
using InsuranceClaimMicroservice.Services;
using Moq;
using NUnit.Framework;

namespace InsuranceClaimMicroserviceTest
{
    class TestValidInsurers
    {
        Mock<IInsuranceClaim> repo;
        ClaimService service;
        List<Insurer> insurers;

        [SetUp]
        public void Setup()
        {
            repo = new Mock<IInsuranceClaim>();
            service = new ClaimService(repo.Object);
            insurers = new List<Insurer>()
            {
                new Insurer { InsurerId=1, InsurerName="LIC", InsurerPackageName="LIC Special Sewa", AmountLimit=35000, DisbursementDuration=3 },
                new Insurer { InsurerId=2, InsurerName="LIC", InsurerPackageName="LIC Basic Sewa", AmountLimit=28000, DisbursementDuration=3 },
                new Insurer { InsurerId=3, InsurerName="Kotak", InsurerPackageName="Kotak Special Sewa", AmountLimit=32000, DisbursementDuration=3 },
                new Insurer { InsurerId=4, InsurerName="Mahindra", InsurerPackageName="Mahindra Basic Sewa", AmountLimit=25000, DisbursementDuration=3 }
            };
        }

        [Test]
        public void CheckingMethod_GetAllInsurer_ReturnsValidInsurerLists()
        {
            repo.Setup(x => x.GetInsurerList()).Returns(insurers);
            var res = service.GetAllInsurer();
            Assert.IsNotNull(res);
        }

        [TestCase("Special")]
        [TestCase("Basic")]
        public void CheckingMethod_GetInsurersByPackage_ReturnsValidInsurerLists(string packageName)
        {
            repo.Setup(x => x.GetInsurerList()).Returns(insurers);
            var res = service.GetAllInsurerByPackage(packageName);
            Assert.IsNotNull(res);
        }
    }
}
