using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class TreeBusiness
    {
        private GardenContext context;

        public TreeBusiness(GardenContext gardenContext)
        {
            context = gardenContext;
        }

        public TreeBusiness()
        {
            context = new GardenContext();
        }

        /// <summary>
        /// Gives all trees in the database.
        /// </summary>
        public List<Tree> GetAllFlowers()
        {
            return context.Trees.ToList();
        }

        /// <summary>
        /// Adds tree in database.
        /// </summary>
        public void Add(Tree tree)
        {
            context.Trees.Add(tree);
            context.SaveChanges();
        }

        /// <summary>
        /// Updates tree.
        /// </summary>
        public void Update(Tree tree)
        {
            var item = context.Trees.Find(tree.Id);
            if (item != null)
            {
                context.Entry(item).CurrentValues.SetValues(tree);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes a tree with wanted id.
        /// </summary>
        public void Delete(int id)
        {
            var item = context.Trees.FirstOrDefault(m => m.Id == id);
            if (item != null)
            {
                context.Trees.Remove(item);
                context.SaveChanges();
            }
        }
    }
}
