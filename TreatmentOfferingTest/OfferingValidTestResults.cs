using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;
using TreatmentOffering.Models;
using TreatmentOffering.OfferingRepository;
using TreatmentOffering.OfferingService;

namespace TreatmentOfferingTest
{
    class OfferingValidTestResults
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
            packages = new List<PatientServicePackageView>()
            {
                new PatientServicePackageView{ PackageId = 1, Ailment="Orthopedics", PackageName="Basic", TestDetails="OTP1, OTP2", Cost=3000, Duration=3 },
                new PatientServicePackageView{ PackageId = 2, Ailment="Orthopedics", PackageName="Special", TestDetails="OTP3, OTP4", Cost=3800, Duration=4 },
                new PatientServicePackageView{ PackageId = 3, Ailment="Urology", PackageName="Basic", TestDetails="UTP1, UTP2", Cost=2800, Duration=3 },
                new PatientServicePackageView{ PackageId = 3, Ailment="Urology", PackageName="Special", TestDetails="UTP3, UTP4", Cost=3200, Duration=3 }
            };
            specialists = new List<SpecialistView>()
            {
                new SpecialistView{SpecialistId=1, Name="John Doe", Expertise="Orthopedics", YearsOfExp=10, Contact=9845673451},
                new SpecialistView{SpecialistId=2, Name="Prashant Hegde", Expertise="Orthopedics", YearsOfExp=4, Contact=8055673452},
                new SpecialistView{SpecialistId=3, Name="Jane Doe", Expertise="Urology", YearsOfExp=12, Contact=9067872211},
                new SpecialistView{SpecialistId=4, Name="Amit Jana", Expertise="Urology", YearsOfExp=4, Contact=8900453498}
            };
        }

        [Test]
        public void CheckingMethod_GetPackages_Returns_ValidPackageList()
        {
            repo.Setup(x => x.AllPackage()).Returns(packages);
            var result = services.GetPackages();
            Assert.IsNotNull(result);
        }
        [TestCase("Special")]
        [TestCase("Basic")]
        public void CheckingMethod_GetPackages_Returns_ValidPackageList_ByName(string packageName)
        {
            repo.Setup(x => x.AllPackage()).Returns(packages);
            var result = services.GetPackagesByName(packageName);
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }
        [Test]
        public void CheckingMethod_GetSpecialistDetails_Returns_ValidSpecialistList()
        {
            repo.Setup(x => x.AllSpecialist()).Returns(specialists);
            var result = services.GetSpecialistDetails();
            Assert.IsNotNull(result);
        }
    }
}
