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
    class TestNullInsurers
    {
        Mock<IInsuranceClaim> repo;
        ClaimService service;
        List<Insurer> insurers;

        [SetUp]
        public void Setup()
        {
            repo = new Mock<IInsuranceClaim>();
            service = new ClaimService(repo.Object);
            insurers = null;
        }

        [Test]
        public void CheckingMethod_GetAllInsurer_ReturnsNullInsurerLists()
        {
            repo.Setup(x => x.GetInsurerList()).Returns(insurers);
            var res = service.GetAllInsurer();
            Assert.IsNull(res);
        }

        [TestCase("General")]
        public void CheckingMethod_GetInsurersByPackage_ReturnsNullInsurerLists(string packageName)
        {
            repo.Setup(x => x.GetInsurerList()).Returns(insurers);
            var res = service.GetAllInsurerByPackage(packageName);
            Assert.IsNull(res);
        }
    }
}
