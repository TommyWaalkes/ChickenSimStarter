using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ChickenSim.Models
{
    public partial class Farms
    {
        public Farms()
        {
            Chickens = new HashSet<Chickens>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Seeds { get; set; }

        public virtual ICollection<Chickens> Chickens { get; set; }
    }
}
