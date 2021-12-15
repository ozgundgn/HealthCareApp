using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HealthCareApp.Models
{
    public partial class City
    {
        public City()
        {
            District = new HashSet<District>();
        }

        public int Id { get; set; }
        public string Cityname { get; set; }

        public virtual ICollection<District> District { get; set; }
    }
}
