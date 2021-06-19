using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TreatmentMicroservice.Models;
using TreatmentMicroservice.TreatmentRepository;

namespace TreatmentMicroserviceTest
{
    class TestServices
    {
        Mock<ITreatmentRepo> mockRepo;
        List<PatientServicePackage> package;
        List<SpecialistView> specialists;
        //List<Patient> patients;
        [SetUp]
        public void Setup()
        {
            mockRepo = new Mock<ITreatmentRepo>();
            package = new List<PatientServicePackage>()
            {
                new PatientServicePackage{PackageId=1, Ailment="Orthopedics", PackageName="Basic", TestDetails="OPT1, OPT2", Cost=30000, Duration=3},
                new PatientServicePackage{PackageId=2, Ailment="Orthopedics", PackageName="Special", TestDetails="OPT3, OPT4", Cost=38000, Duration=4},
                new PatientServicePackage{PackageId=3, Ailment="Urology", PackageName="Basic", TestDetails="UTP1, UTP2", Cost=28000, Duration=3},
                new PatientServicePackage{PackageId=4, Ailment="Urology", PackageName="Special", TestDetails="UTP3, UTP4", Cost=32000, Duration=3}
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
        public void TestingGetPackageList_Returns_ValidPackageList()
        {
            var res = mockRepo.Setup(x => x.GetPackageList()).ReturnsAsync(package);
            Assert.IsNotNull(res);
        }
        [Test]
        public void TestingGetSpecialists_Returns_SpecialistsList()
        {
            var res = mockRepo.Setup(x => x.GetSpecialists()).ReturnsAsync(specialists);
            Assert.IsNotNull(res);
        }
    }
}