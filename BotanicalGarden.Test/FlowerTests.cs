using Business;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BotanicalGarden.Test
{
    public class FlowerTests
    {

        [TestCase]
        public void Gives_All_Flowers()
        {
            var data = new List<Flower>
            {
                new Flower { Name="First" },
                new Flower { Name="Second" },
                new Flower { Name="Third" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Flower>>();
            mockSet.As<IQueryable<Flower>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Flower>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Flower>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Flower>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<GardenContext>();
            mockContext.Setup(c => c.Flowers).Returns(mockSet.Object);

            var business = new FlowerBusiness(mockContext.Object);
            var Flowers = business.GetAllFlowers();

            Assert.AreEqual(3, Flowers.Count);
            Assert.AreEqual("First", Flowers[0].Name);
            Assert.AreEqual("Second", Flowers[1].Name);
            Assert.AreEqual("Third", Flowers[2].Name);
        }

        [TestCase]
        public void Add_Flower()
        {
            var mockSet = new Mock<DbSet<Flower>>();
            var flower = new Flower();
            var mockContext = new Mock<GardenContext>();
            mockContext.Setup(m => m.Flowers).Returns(mockSet.Object);

            var business = new FlowerBusiness(mockContext.Object);
            business.Add(flower);

            mockSet.Verify(m => m.Add(It.IsAny<Flower>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestCase]
        public void Gives_Flower_By_Name()
        {
            var data = new List<Flower>()
            {
                new Flower{Id=1, Name="Flower1"},
                new Flower{Id=2, Name="Flower2" },
                new Flower{Id=3, Name="Flower3"},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Flower>>();
            mockSet.As<IQueryable<Flower>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Flower>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Flower>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Flower>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<GardenContext>();
            mockContext.Setup(c => c.Flowers).Returns(mockSet.Object);

            var business = new FlowerBusiness(mockContext.Object);

            var flower = business.GetFlowerByName("Flower1");
            Assert.AreEqual("Flower1", flower.Name);
        }

        [TestCase]
        public void Remove_Flower()
        {
            var data = new List<Flower>()
            {
                new Flower{Id=1, Name="Flower1"},
                new Flower{Id=2, Name="Flower2" },
                new Flower{Id=3, Name="Flower3"},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Flower>>();
            mockSet.As<IQueryable<Flower>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Flower>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Flower>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Flower>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<GardenContext>();
            mockContext.Setup(x => x.Flowers).Returns(mockSet.Object);

            var business = new FlowerBusiness(mockContext.Object);
            var flowers = business.GetAllFlowers();

            int deletedFlowerId = 1; business.Delete(flowers[0].Id);

            Assert.IsNull(business.GetAllFlowers().FirstOrDefault(x => x.Id == deletedFlowerId));
        }
    }
}