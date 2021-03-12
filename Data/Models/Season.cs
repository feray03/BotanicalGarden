using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{ 
    public class Season
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Flower> Flowers { get; set; }
        public virtual ICollection<Tree> Trees { get; set; }
        public virtual ICollection<Shrub> Shrubs { get; set; }
        public virtual ICollection<Cactus> Cactuses { get; set; }
        public virtual ICollection<Grass> Grasses { get; set; }
    }
}
