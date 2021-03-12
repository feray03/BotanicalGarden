using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{ 
    public class Cactus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Height { get; set; }
        public string Thorns { get; set; }
        public int SeasonsId { get; set; }
        public virtual Season Seasons { get; set; }
    }
}
