using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class ShrubBusiness
    {
        private GardenContext context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gardenContext"></param>
        public ShrubBusiness(GardenContext gardenContext)
        {
            context = gardenContext;
        }

        public ShrubBusiness()
        {
            context = new GardenContext();
        }

        /// <summary>
        /// Gives all shrubs in the database.
        /// </summary>
        /// <returns>all shrubs from the database</returns>
        public List<Shrub> GetAllFlowers()
        {
            return context.Shrubs.ToList();
        }

        /// <summary>
        /// Adds shrub in database.
        /// </summary>
        /// <param name="shrub">the shrub that will be added</param>
        public void Add(Shrub shrub)
        {
            context.Shrubs.Add(shrub);
            context.SaveChanges();
        }

        /// <summary>
        /// Updates shrub.
        /// </summary>
        /// <param name="shrub">the shrub that will be updated</param>
        public void Update(Shrub shrub)
        {
            var item = context.Shrubs.Find(shrub.Id);
            if (item != null)
            {
                context.Entry(item).CurrentValues.SetValues(shrub);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes a shrub with wanted id.
        /// </summary>
        /// <param name="id">id of the wanted shrub</param>
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
