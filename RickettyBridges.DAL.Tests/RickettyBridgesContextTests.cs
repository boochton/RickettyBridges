using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RickettyBridges.DAL.Tests
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using Moq;

    using RickettyBridges.DAL.Entities;

    [TestClass]
    public class RickettyBridgesContextTests
    {
        [TestMethod]
        public void GetAssetForIdThatExistsReturnsAsset()
        {
            var data = new List<Asset> { new Asset { Id = 23, DeckType = new DeckType(), Name = "Name To Look For" } }.AsQueryable();
            var mockDbSet = new Mock<DbSet<Asset>>();
            mockDbSet.As<IQueryable<Asset>>().Setup(m => m.Provider).Returns(data.Provider); 
            mockDbSet.As<IQueryable<Asset>>().Setup(m => m.Expression).Returns(data.Expression); 
            mockDbSet.As<IQueryable<Asset>>().Setup(m => m.ElementType).Returns(data.ElementType); 
            mockDbSet.As<IQueryable<Asset>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator()); 
 
            var mockContext = new Mock<RickettyBridgesContext>(); 
            mockContext.Setup(c => c.Assets.AsNoTracking()).Returns(mockDbSet.Object);

            var sut = new RickettyBridgesService(mockContext.Object);
            var asset = sut.GetAsset(23);

            Assert.IsNotNull(asset);
            Assert.AreEqual(23, asset.Id);
            Assert.AreEqual("Name To Look For", asset.Name);
        }

        [TestMethod]
        public void GetAssetForIdThatDoesNotExistReturnsNull()
        {
            var data = new List<Asset> { new Asset { Id = 23, DeckType = new DeckType(), Name = "Name To Look For" } }.AsQueryable();
            var mockDbSet = new Mock<DbSet<Asset>>();
            mockDbSet.As<IQueryable<Asset>>().Setup(m => m.Provider).Returns(data.Provider); 
            mockDbSet.As<IQueryable<Asset>>().Setup(m => m.Expression).Returns(data.Expression); 
            mockDbSet.As<IQueryable<Asset>>().Setup(m => m.ElementType).Returns(data.ElementType); 
            mockDbSet.As<IQueryable<Asset>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator()); 
 
            var mockContext = new Mock<RickettyBridgesContext>(); 
            mockContext.Setup(c => c.Assets.AsNoTracking()).Returns(mockDbSet.Object);

            var sut = new RickettyBridgesService(mockContext.Object);
            var asset = sut.GetAsset(25);

            Assert.IsNull(asset);
        }
    }
}
