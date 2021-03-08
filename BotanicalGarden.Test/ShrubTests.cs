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
    }
}
