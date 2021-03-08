using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class SeasonBusiness
    {
        private GardenContext context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gardenContext"></param>
        public SeasonBusiness(GardenContext gardenContext)
        {
            context = gardenContext;
        }

        public SeasonBusiness()
        {
            context = new GardenContext();
        }

        /// <summary>
        /// Gives season with wanted name. 
        /// </summary>
        /// <param name="id">id of the wanted season</param>
        /// <returns>season with wanted id</returns>
        public Season GetSeasonByName(string name)
        {
            return context.Seasons.SingleOrDefault(season => season.Name == name);
        }

        /// <summary>
        /// Gives all seasons in the database.
        /// </summary>
        /// <returns>all seasons from the database</returns>
        public List<Season> GetAllSeasons()
        {
            return context.Seasons.ToList();
        }
    }
}
