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
        /// Gives shrub with wanted name. 
        /// </summary>
        /// <param name="id">id of the wanted shrub</param>
        /// <returns>shrub with wanted id</returns>
        public Shrub GetShrubByName(string name)
        {
            return context.Shrubs.SingleOrDefault(shrub => shrub.Name == name);
        }

        /// <summary>
        /// Gives all shrubs in the database.
        /// </summary>
        /// <returns>all shrubs from the database</returns>
        public List<Shrub> GetAllShrubs()
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
            var item = context.Shrubs.FirstOrDefault(m => m.Id == id);
            if (item != null)
            {
                context.Shrubs.Remove(item);
                context.SaveChanges();
            }
        }

        public Season GetSeason(string name)
        {
            var Shrub = this.GetShrubByName(name);
            return context.Seasons.Find(Shrub.SeasonsId);
        }
    }
}
