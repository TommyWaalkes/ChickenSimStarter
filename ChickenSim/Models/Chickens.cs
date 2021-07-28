using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ChickenSim.Models
{
    public partial class Chickens
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public decimal? Smarts { get; set; }
        public decimal? Strength { get; set; }
        public decimal? Speed { get; set; }
        public decimal? Luck { get; set; }
        public string Color { get; set; }
        public int? FarmId { get; set; }

        public virtual Farms Farm { get; set; }
    }
}
