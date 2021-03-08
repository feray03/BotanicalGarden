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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gardenContext"></param>
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
        /// <returns>all trees from the database</returns>
        public List<Tree> GetAllTrees()
        {
            return context.Trees.ToList();
        }

        /// <summary>
        /// Gives tree with wanted name. 
        /// </summary>
        /// <param name="id">id of the wanted tree</param>
        /// <returns>tree with wanted id</returns>
        public Tree GetTreeByName(string name)
        {
            return context.Trees.SingleOrDefault(tree => tree.Name == name);
        }

        /// <summary>
        /// Adds tree in database.
        /// </summary>
        /// <param name="tree">the tree that will be added</param>
        public void Add(Tree tree)
        {
            context.Trees.Add(tree);
            context.SaveChanges();
        }

        /// <summary>
        /// Updates tree.
        /// </summary>
        /// <param name="tree">the tree that will be updated</param>
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
        /// <param name="id">id of the wanted tree</param>
        public void Delete(int id)
        {
            var item = context.Trees.FirstOrDefault(m => m.Id == id);
            if (item != null)
            {
                context.Trees.Remove(item);
                context.SaveChanges();
            }
        }

        public Season GetSeason(string name)
        {
            var Tree = this.GetTreeByName(name);
            return context.Seasons.Find(Tree.SeasonsId);
        }
    }
}
