using Business;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BotanicalGarden.Test
{
     public class CactusTests
    {
        [TestCase]
        public void Gives_All_Flowers()
        {
            var data = new List<Cactus>
            {
                new Cactus{ Name="First" },
                new Cactus { Name="Second" },
                new Cactus { Name="Third" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Cactus>>();
            mockSet.As<IQueryable<Cactus>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Cactus>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Cactus>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Cactus>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<GardenContext>();
            mockContext.Setup(c => c.Cactuses).Returns(mockSet.Object);
            var business = new CactusBusiness(mockContext.Object);
            var Cactuses = business.GetAllCactuses();

            Assert.AreEqual(3, Cactuses.Count);
            Assert.AreEqual("First", Cactuses[0].Name);
            Assert.AreEqual("Second", Cactuses[1].Name);
            Assert.AreEqual("Third", Cactuses[2].Name);
        }
        [TestCase]
        public void Add_Cactus()
        {
            var mockSet = new Mock<DbSet<Cactus>>();
            var cactus = new Cactus();
            var mockContext = new Mock<GardenContext>();
            mockContext.Setup(m => m.Cactuses).Returns(mockSet.Object);

            var business = new CactusBusiness(mockContext.Object);
            business.Add(cactus);

            mockSet.Verify(m => m.Add(It.IsAny<Cactus>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestCase]
        public void Gives_Cactus_By_Name()
        {
            var data = new List<Cactus>()
            {
                new Cactus{Id=1, Name="Cactus1"},
                new Cactus{Id=2, Name="Cactus2" },
                new Cactus{Id=3, Name="Cactus3"},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Cactus>>();
            mockSet.As<IQueryable<Cactus>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Cactus>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Cactus>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Cactus>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<GardenContext>();
            mockContext.Setup(c => c.Cactuses).Returns(mockSet.Object);

            var business = new CactusBusiness(mockContext.Object);

            var cactus = business.GetCactusByName("Cactus1");
            Assert.AreEqual("Cactus1", cactus.Name);
        }

        [TestCase]
        public void Remove_Cactus()
        {
            var data = new List<Cactus>()
            {
                new Cactus{Id=1, Name="Cactus1"},
                new Cactus{Id=2, Name="Cactus2" },
                new Cactus{Id=3, Name="Cactus3"},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Cactus>>();
            mockSet.As<IQueryable<Cactus>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Cactus>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Cactus>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Cactus>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<GardenContext>();
            mockContext.Setup(x => x.Cactuses).Returns(mockSet.Object);

            var business = new CactusBusiness(mockContext.Object);
            var cactuses = business.GetAllCactuses();

            int deletedCactusId = 1; business.Delete(cactuses[0].Id);

            Assert.IsNull(business.GetAllCactuses().FirstOrDefault(x => x.Id == deletedCactusId));
        }
    }
}
    

