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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gardenContext"></param>
        public CactusBusiness(GardenContext gardenContext)
        {
            context = gardenContext;
        }

        public CactusBusiness()
        {
            context = new GardenContext();
        }

        /// <summary>
        /// Gives cactus with wanted name. 
        /// </summary>
        /// <param name="id">id of the wanted cactus</param>
        /// <returns>cactus with wanted id</returns>
        public Cactus GetCactusByName(string name)
        {
            return context.Cactuses.SingleOrDefault(cactus => cactus.Name == name);
        }

        /// <summary>
        /// Gives all cactuses in the database.
        /// </summary>
        /// <returns>all cactuses from the database</returns>
        public List<Cactus> GetAllCactuses()
        {
            return context.Cactuses.ToList();
        }

        /// <summary>
        /// Adds cactus in database.
        /// </summary>
        /// <param name="cactus">the cactus that will be added</param>
        public void Add(Cactus cactus)
        {
            context.Cactuses.Add(cactus);
            context.SaveChanges();
        }

        /// <summary>
        /// Updates cactus.
        /// </summary>
        /// <param name="cactus">the cactus that will be updated</param>
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
        /// <param name="id">id of the wanted cactus</param>
        public void Delete(int id)
        {
            var item = context.Cactuses.FirstOrDefault(m => m.Id == id);
            if (item != null)
            {
                context.Cactuses.Remove(item);
                context.SaveChanges();
            }
        }

        public Season GetSeason(string name)
        {
            var Cactus = this.GetCactusByName(name);
            return context.Seasons.Find(Cactus.SeasonsId);
        }
    }
}
