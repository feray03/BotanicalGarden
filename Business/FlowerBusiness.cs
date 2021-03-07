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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gardenContext"></param>
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
        /// <returns>all flowers from the database</returns>
        public List<Flower> GetAllFlowers()
        {
            return context.Flowers.ToList();
        }

        /// <summary>
        /// Gives flower with wanted name. 
        /// </summary>
        /// <param name="id">id of the wanted flower</param>
        /// <returns>flower with wanted id</returns>
        public Flower GetFlowerByName(string name)
        {
            return context.Flowers.SingleOrDefault(flower => flower.Name == name);
        }
        /// <summary>
        /// Adds flower in database.
        /// </summary>
        /// <param name="flower">the flower that will be added</param>
        public void Add(Flower flower)
            {
                context.Flowers.Add(flower);
                context.SaveChanges();
            }

            /// <summary>
            /// Updates flower.
            /// </summary>
            /// <param name="flower">the flower that will be updated</param>
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
            /// <param name="id">id of the wanted flower</param>
            public void Delete(int id)
            {
                var item = context.Flowers.FirstOrDefault(m => m.Id == id);
                if (item != null)
                {
                    context.Flowers.Remove(item);
                    context.SaveChanges();
                }
            }

            public Season GetSeason(string name)
            {
                var Flower = this.GetFlowerByName(name);
                return context.Seasons.Find(Flower.SeasonsId);
            }

       
    }
}
