using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Talks.CodeToDiFor.MVC5Web;
using Talks.CodeToDiFor.MVC5Web.Controllers;
using Talks.PCL.SuperSpyLib;
using Rhino.Mocks;
using System.Text.RegularExpressions;

namespace Talks.CodeToDiFor.MVC5Web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private ISpyLogger logMock;
        private IMessageSender senderMock;

        [TestInitialize]
        public void SetUp()
        {
            logMock = MockRepository.GenerateMock<ISpyLogger>();
            senderMock = MockRepository.GenerateStub<IMessageSender>();
        }


        [TestMethod]
        public void Index()
        {
            // Arrange -- no dependendies - poor man's DI
            HomeController controller = new HomeController(logMock, senderMock);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController(logMock, senderMock);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController(logMock, senderMock);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
