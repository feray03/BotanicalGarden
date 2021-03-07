using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class CactusBusiness
    {
        private GardenContext context;

        public CactusBusiness(GardenContext gardenContext)
        {
            context = gardenContext;
        }

        public CactusBusiness()
        {
            context = new GardenContext();
        }

        /// <summary>
        /// Gives all cactus in the database.
        /// </summary>
        public List<Cactus> GetAllFlowers()
        {
            return context.Cactuses.ToList();
        }

        /// <summary>
        /// Adds cactus in database.
        /// </summary>
        public void Add(Cactus cactus)
        {
            context.Cactuses.Add(cactus);
            context.SaveChanges();
        }

        /// <summary>
        /// Updates cactus.
        /// </summary>
        public void Update(Cactus cactus)
        {
            var item = context.Cactuses.Find(cactus.Id);
            if (item != null)
            {
                context.Entry(item).CurrentValues.SetValues(cactus);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes a cactus with wanted id.
        /// </summary>
        public void Delete(int id)
        {
            var item = context.Cactuses.FirstOrDefault(m => m.Id == id);
            if (item != null)
            {
                context.Cactuses.Remove(item);
                context.SaveChanges();
            }
        }
    }
}
