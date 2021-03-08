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
    public class ShrubTests
    {
        [TestCase]
        public void Gives_All_Shrubs()
        {
            var data = new List<Shrub>
            {
                new Shrub { Name="First" },
                new Shrub { Name="Second" },
                new Shrub { Name="Third" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Shrub>>();
            mockSet.As<IQueryable<Shrub>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Shrub>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Shrub>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Shrub>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<GardenContext>();
            mockContext.Setup(c => c.Shrubs).Returns(mockSet.Object);

            var business = new ShrubBusiness(mockContext.Object);
            var Shrubs = business.GetAllShrubs();

            Assert.AreEqual(3, Shrubs.Count);
            Assert.AreEqual("First", Shrubs[0].Name);
            Assert.AreEqual("Second", Shrubs[1].Name);
            Assert.AreEqual("Third", Shrubs[2].Name);
        }

        [TestCase]
        public void Add_Shrub()
        {
            var mockSet = new Mock<DbSet<Shrub>>();
            var shrub = new Shrub();
            var mockContext = new Mock<GardenContext>();
            mockContext.Setup(m => m.Shrubs).Returns(mockSet.Object);

            var business = new ShrubBusiness(mockContext.Object);
            business.Add(shrub);

            mockSet.Verify(m => m.Add(It.IsAny<Shrub>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestCase]
        public void Gives_Shrub_By_Name()
        {
            var data = new List<Shrub>()
            {
                new Shrub{Id=1, Name="Shrub1"},
                new Shrub{Id=2, Name="Shrub2" },
                new Shrub{Id=3, Name="Shrub3"},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Shrub>>();
            mockSet.As<IQueryable<Shrub>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Shrub>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Shrub>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Shrub>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<GardenContext>();
            mockContext.Setup(c => c.Shrubs).Returns(mockSet.Object);

            var business = new ShrubBusiness(mockContext.Object);

            var shrub = business.GetShrubByName("Shrub1");
            Assert.AreEqual("Shrub1", shrub.Name);
        }

        [TestCase]
        public void Remove_Shrub()
        {
            var data = new List<Shrub>()
            {
                new Shrub{Id=1, Name="Shrub1"},
                new Shrub{Id=2, Name="Shrub2" },
                new Shrub{Id=3, Name="Shrub3"},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Shrub>>();
            mockSet.As<IQueryable<Shrub>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Shrub>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Shrub>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Shrub>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<GardenContext>();
            mockContext.Setup(x => x.Shrubs).Returns(mockSet.Object);

            var business = new ShrubBusiness(mockContext.Object);
            var shrubs = business.GetAllShrubs();

            int deletedShrubId = 1; business.Delete(shrubs[0].Id);

            Assert.IsNull(business.GetAllShrubs().FirstOrDefault(x => x.Id == deletedShrubId));
        }
    }
}
