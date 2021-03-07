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
        public List<Shrub> GetAllFlowers()
        {
            return context.Shrubs.ToList();
        }

        /// <summary>
        /// Adds shrub in database.
        /// </summary>
        public void Add(Shrub shrub)
        {
            context.Shrubs.Add(shrub);
            context.SaveChanges();
        }

        /// <summary>
        /// Updates shrub.
        /// </summary>
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
