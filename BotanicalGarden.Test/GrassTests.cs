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
      public class GrassTests
    {
        [TestCase]
        public void Gives_All_Flowers()
        {
            var data = new List<Grass>
            {
                new Grass{ Name="First" },
                new Grass { Name="Second" },
                new Grass { Name="Third" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Grass>>();
            mockSet.As<IQueryable<Grass>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Grass>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Grass>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Grass>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<GardenContext>();
            mockContext.Setup(c => c.Grasses).Returns(mockSet.Object);
            var business = new GrassBusiness(mockContext.Object);
            var Grasses = business.GetAllGrasses();

            Assert.AreEqual(3, Grasses.Count);
            Assert.AreEqual("First", Grasses[0].Name);
            Assert.AreEqual("Second", Grasses[1].Name);
            Assert.AreEqual("Third", Grasses[2].Name);
        }
        [TestCase]
        public void Add_Grass()
        {
            var mockSet = new Mock<DbSet<Grass>>();
            var grass = new Grass();
            var mockContext = new Mock<GardenContext>();
            mockContext.Setup(m => m.Grasses).Returns(mockSet.Object);

            var business = new GrassBusiness(mockContext.Object);
            business.Add(grass);

            mockSet.Verify(m => m.Add(It.IsAny<Grass>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestCase]
        public void Gives_Grass_By_Name()
        {
            var data = new List<Grass>()
            {
                new Grass{Id=1, Name="Grass1"},
                new Grass{Id=2, Name="Grass2" },
                new Grass{Id=3, Name="Grass3"},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Grass>>();
            mockSet.As<IQueryable<Grass>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Grass>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Grass>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Grass>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<GardenContext>();
            mockContext.Setup(c => c.Grasses).Returns(mockSet.Object);

            var business = new GrassBusiness(mockContext.Object);

            var grass = business.GetGrassByName("Grass1");
            Assert.AreEqual("Grass1", grass.Name);
        }

        [TestCase]
        public void Remove_Grass()
        {
            var data = new List<Grass>()
            {
                new Grass{Id=1, Name="Grass1"},
                new Grass{Id=2, Name="Grass2" },
                new Grass{Id=3, Name="Grass3"},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Grass>>();
            mockSet.As<IQueryable<Grass>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Grass>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Grass>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Grass>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<GardenContext>();
            mockContext.Setup(x => x.Grasses).Returns(mockSet.Object);

            var business = new GrassBusiness(mockContext.Object);
            var grasses = business.GetAllGrasses();

            int deletedGrassId = 1; business.Delete(grasses[0].Id);

            Assert.IsNull(business.GetAllGrasses().FirstOrDefault(x => x.Id == deletedGrassId));
        }
    }
}
    

