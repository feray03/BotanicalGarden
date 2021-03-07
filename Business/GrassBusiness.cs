using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class GrassBusiness
    {
        private GardenContext context;

        public GrassBusiness(GardenContext gardenContext)
        {
            context = gardenContext;
        }

        public GrassBusiness()
        {
            context = new GardenContext();
        }

        /// <summary>
        /// Gives all Grass in the database.
        /// </summary>
        public List<Grass> GetAllFlowers()
        {
            return context.Grasses.ToList();
        }

        /// <summary>
        /// Adds Grass in database.
        /// </summary>
        public void Add(Grass grass)
        {
            context.Grasses.Add(grass);
            context.SaveChanges();
        }

        /// <summary>
        /// Updates Grass.
        /// </summary>
        public void Update(Grass grass)
        {
            var item = context.Grasses.Find(grass.Id);
            if (item != null)
            {
                context.Entry(item).CurrentValues.SetValues(grass);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes a Grass with wanted id.
        /// </summary>
        public void Delete(int id)
        {
            var item = context.Grasses.FirstOrDefault(m => m.Id == id);
            if (item != null)
            {
                context.Grasses.Remove(item);
                context.SaveChanges();
            }
        }
    }
}
