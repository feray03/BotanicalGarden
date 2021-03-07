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
        /// Gives all seasons in the database.
        /// </summary>
        /// <returns>all seasons from the database</returns>
        public List<Season> GetAllFlowers()
        {
            return context.Seasons.ToList();
        }
    }
}
