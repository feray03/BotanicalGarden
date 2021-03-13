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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gardenContext"></param>
        public GrassBusiness(GardenContext gardenContext)
        {
            context = gardenContext;
        }

        public GrassBusiness()
        {
            context = new GardenContext();
        }

        /// <summary>
        /// Gives grass with wanted name. 
        /// </summary>
        /// <param name="id">id of the wanted grass</param>
        /// <returns>grass with wanted id</returns>
        public Grass GetGrassByName(string name)
        {
            return context.Grasses.SingleOrDefault(grass => grass.Name == name);
        }

        /// <summary>
        /// Gives all Grasses in the database.
        /// </summary>
        /// <returns>all grases from the database</returns>
        public List<Grass> GetAllGrasses()
        {
            return context.Grasses.ToList();
        }

        /// <summary>
        /// Adds Grass in database.
        /// </summary>
        /// <param name="grass">the grass that will be added</param>
        public void Add(Grass grass)
        {
            context.Grasses.Add(grass);
            context.SaveChanges();
        }

        /// <summary>
        /// Updates Grass.
        /// </summary>
        /// <param name="grass">the grass that will be updated</param>
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
        /// Deletes a grass with wanted id.
        /// </summary>
        /// <param name="id">id of the wanted grass</param>
        public void Delete(int id)
        {
            var item = context.Grasses.FirstOrDefault(m => m.Id == id);
            if (item != null)
            {
                context.Grasses.Remove(item);
                context.SaveChanges();
            }
        }

        public Season GetSeason(string name)
        {
            var Grass = this.GetGrassByName(name);
            return context.Seasons.Find(Grass.SeasonsId);
        }

        /// <summary>
        /// Returns an array of grasses with the corresponding season.
        /// </summary>
        /// <param name="seasonId"></param>
        /// <returns></returns>
        public List<Grass> SearchBySeason(int seasonId)
        {
            Season GrassSeason = context.Seasons.SingleOrDefault(season => season.Id == seasonId);
            return context.Grasses.Where(grass => grass.SeasonsId == GrassSeason.Id).ToList();
        }
    }
}
