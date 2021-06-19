using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TreatmentOffering.Models;
using TreatmentOffering.OfferingRepository;
using TreatmentOffering.OfferingService;
using NUnit.Framework;

namespace TreatmentOfferingTest
{
    class OfferingNullTestResults
    {
        Mock<IOfferingServices> repo;
        TreatmentServices services;
        List<PatientServicePackageView> packages;
        List<SpecialistView> specialists;

        [SetUp]
        public void Setup()
        {
            repo = new Mock<IOfferingServices>();
            services = new TreatmentServices(repo.Object);
            packages = null;
            specialists = null;
        }
        [Test]
        public void CheckingMethod_GetPackages_Returns_NullList()
        {
            repo.Setup(x => x.AllPackage()).Returns(packages);
            var result = services.GetPackages();
            Assert.IsNull(result);
        }
        [TestCase("General")]
        public void CheckingMethod_GetPackages_Returns_EmptyList_ByName(string packageName)
        {
            repo.Setup(x => x.AllPackage()).Returns(new List<PatientServicePackageView>()
            {
                new PatientServicePackageView{ PackageId = 1, Ailment="Orthopedics", PackageName="Basic", TestDetails="OTP1, OTP2", Cost=3000, Duration=3 },
                new PatientServicePackageView{ PackageId = 2, Ailment="Orthopedics", PackageName="Special", TestDetails="OTP3, OTP4", Cost=3800, Duration=4 },
                new PatientServicePackageView{ PackageId = 3, Ailment="Urology", PackageName="Basic", TestDetails="UTP1, UTP2", Cost=2800, Duration=3 },
                new PatientServicePackageView{ PackageId = 3, Ailment="Urology", PackageName="Special", TestDetails="UTP3, UTP4", Cost=3200, Duration=3 }
            });
            var result = services.GetPackagesByName(packageName);
            Assert.AreEqual(0, result.Count);
        }
        [Test]
        public void CheckingMethod_GetSpecialistDetails_Returns_NullList()
        {
            repo.Setup(x => x.AllSpecialist()).Returns(specialists);
            var result = services.GetSpecialistDetails();
            Assert.IsNull(result);
        }
    }
}
