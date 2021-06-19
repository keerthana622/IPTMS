using System;
using System.Collections.Generic;
using System.Text;
using AuthorizationMicroservice.Repository;
using AuthorizationMicroservice.Service;
using Moq;
using NUnit.Framework;

namespace AuthorizationMicroserviceTest
{
    class TestingTokenGeneration
    {
        Mock<IAuthorization> repo;
        AuthorizationService service;
        [SetUp]
        public void Setup()
        {
            repo = new Mock<IAuthorization>();
            service = new AuthorizationService(repo.Object);
        }
        [TestCase("admin@iptm.com", "Awesome123")]
        public void TestingMethod_CreateToken_ReturnsValidToken(string user, string pass)
        {
            string generatedtoken = "moertartuio5662gafreyooamd";
            repo.Setup(x => x.CreateToken(It.IsAny<string>(), It.IsAny<string>())).Returns(generatedtoken);
            string restoken = service.GetToken(user, pass);
            Assert.AreEqual(restoken, generatedtoken);
        }
        [TestCase("admin@iptm.com", "Awesome123")]
        public void TestingMethod_CreateToken_ReturnsNullToken(string user, string pass)
        {
            string generatedtoken = null;
            repo.Setup(x => x.CreateToken(It.IsAny<string>(), It.IsAny<string>())).Returns(generatedtoken);
            string restoken = service.GetToken(user, pass);
            Assert.IsNull(restoken);
        }
    }
}
