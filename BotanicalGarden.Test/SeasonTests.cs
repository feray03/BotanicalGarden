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
    public class SeasonTests
    {
        [TestCase]
        public void Gives_All_Seasons()
        {
            var data = new List<Season>
            {
                new Season { Name="First" },
                new Season { Name="Second" },
                new Season { Name="Third" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Season>>();
            mockSet.As<IQueryable<Season>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Season>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Season>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Season>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<GardenContext>();
            mockContext.Setup(c => c.Seasons).Returns(mockSet.Object);

            var business = new SeasonBusiness(mockContext.Object);
            var Seasons = business.GetAllSeasons();

            Assert.AreEqual(3, Seasons.Count);
            Assert.AreEqual("First", Seasons[0].Name);
            Assert.AreEqual("Second", Seasons[1].Name);
            Assert.AreEqual("Third", Seasons[2].Name);
        }

        [TestCase]
        public void Gives_Season_By_Name()
        {
            var data = new List<Season>()
            {
                new Season{Id=1, Name="Season1"},
                new Season{Id=2, Name="Season2"},
                new Season{Id=3, Name="Season3"},
                new Season{Id=4, Name="Season4"},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Season>>();
            mockSet.As<IQueryable<Season>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Season>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Season>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Season>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<GardenContext>();
            mockContext.Setup(c => c.Seasons).Returns(mockSet.Object);

            var business = new SeasonBusiness(mockContext.Object);

            var season = business.GetSeasonByName("Season1");
            Assert.AreEqual("Season1", season.Name);
        }
    }
}
