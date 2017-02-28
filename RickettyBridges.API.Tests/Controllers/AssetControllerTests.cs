using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RickettyBridges.API;
using RickettyBridges.API.Controllers;

namespace RickettyBridges.API.Tests.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Remoting.Messaging;
    using System.Security.Cryptography.X509Certificates;
    using log4net;
    using Moq;
    using RickettyBridges.API.Autofac.Helpers;
    using RickettyBridges.API.Messages;
    using RickettyBridges.DAL.Entities;
    using RickettyBridges.DAL.Enums;
    using RickettyBridges.DAL.Interfaces;

    using Asset = RickettyBridges.API.Models.Asset;

    [TestClass]
    public class AssetControllerTests
    {
        [TestMethod]
        public void ExampleOfBasicIdUnitTest()
        {
            // Arrange
            var mockLogger = new Mock<ILog>();            
            var mockRickettyBridgeDal = new Mock<IRickettyBridgeService>();
            var returnedAsset = new DAL.Entities.Asset { Id = 22, Name = "Test Returned Name", DeckType = new DeckType()};
            mockRickettyBridgeDal.Setup(x => x.GetAsset(22)).Returns(returnedAsset);

            AssetController controller = new AssetController(mockLogger.Object, mockRickettyBridgeDal.Object);

            // Act
            var result = controller.Id(22);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(22, result.Id);            
            Assert.AreEqual("Test Returned Name", result.Name);   
        }
    }
}
