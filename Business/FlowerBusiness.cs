using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class FlowerBusiness
    {
        private GardenContext context;

        public FlowerBusiness(GardenContext gardenContext)
        {
            context = gardenContext;
        }

        public FlowerBusiness()
        {
            context = new GardenContext();
        }

        /// <summary>
        /// Gives all flowers in the database.
        /// </summary>
        public List<Flower> GetAllFlowers()
        {
            return context.Flowers.ToList();
        }

        /// <summary>
        /// Adds flower in database.
        /// </summary>
        public void Add(Flower flower)
        {
            context.Flowers.Add(flower);
            context.SaveChanges();
        }

        /// <summary>
        /// Updates flower.
        /// </summary>
        public void Update(Flower flower)
        {
            var item = context.Flowers.Find(flower.Id);
            if (item != null)
            {
                context.Entry(item).CurrentValues.SetValues(flower);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes a flower with wanted id.
        /// </summary>
        public void Delete(int id)
        {
            var item = context.Flowers.FirstOrDefault(m => m.Id == id);
            if (item != null)
            {
                context.Flowers.Remove(item);
                context.SaveChanges();
            }
        }
    }
}
