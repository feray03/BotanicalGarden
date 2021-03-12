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
    public class TreeTests
    {
        [TestCase]
        public void Gives_All_Flowers()
        {
            var data = new List<Tree>
            {
                new Tree { Name="First" },
                new Tree { Name="Second" },
                new Tree { Name="Third" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Tree>>();
            mockSet.As<IQueryable<Tree>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Tree>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Tree>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Tree>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<GardenContext>();
            mockContext.Setup(c => c.Trees).Returns(mockSet.Object);

            var business = new TreeBusiness(mockContext.Object);
            var Trees = business.GetAllTrees();

            Assert.AreEqual(3, Trees.Count);
            Assert.AreEqual("First", Trees[0].Name);
            Assert.AreEqual("Second", Trees[1].Name);
            Assert.AreEqual("Third", Trees[2].Name);
        }

        [TestCase]
        public void Add_Tree()
        {
            var mockSet = new Mock<DbSet<Tree>>();
            var tree = new Tree();
            var mockContext = new Mock<GardenContext>();
            mockContext.Setup(m => m.Trees).Returns(mockSet.Object);

            var business = new TreeBusiness(mockContext.Object);
            business.Add(tree);

            mockSet.Verify(m => m.Add(It.IsAny<Tree>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestCase]
        public void Gives_Tree_By_Name()
        {
            var data = new List<Tree>()
            {
                new Tree{Id=1, Name="Tree1"},
                new Tree{Id=2, Name="Tree2" },
                new Tree{Id=3, Name="Tree3"},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Tree>>();
            mockSet.As<IQueryable<Tree>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Tree>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Tree>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Tree>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<GardenContext>();
            mockContext.Setup(c => c.Trees).Returns(mockSet.Object);

            var business = new TreeBusiness(mockContext.Object);

            var tree = business.GetTreeByName("Tree1");
            Assert.AreEqual("Tree1", tree.Name);
        }

        [TestCase]
        public void Update_Tree()
        {
            var mockContext = new Mock<GardenContext>(); ;
            var treeBusiness = new TreeBusiness();
            var Tree = new Tree() { Name = "Tree1" };
            try { treeBusiness.Update(Tree); }
            catch { mockContext.Verify(m => m.Entry(It.IsAny<Tree>()), Times.Once()); }
        }

        [TestCase]
        public void Remove_Tree()
        {
            var data = new List<Tree>()
            {
                new Tree{Id=1, Name="Tree1"},
                new Tree{Id=2, Name="Tree2" },
                new Tree{Id=3, Name="Tree3"},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Tree>>();
            mockSet.As<IQueryable<Tree>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Tree>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Tree>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Tree>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<GardenContext>();
            mockContext.Setup(x => x.Trees).Returns(mockSet.Object);

            var business = new TreeBusiness(mockContext.Object);
            var trees = business.GetAllTrees();

            int deletedTreeId = 1; business.Delete(trees[0].Id);

            Assert.IsNull(business.GetAllTrees().FirstOrDefault(x => x.Id == deletedTreeId));
        }
    }
}
