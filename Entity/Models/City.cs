using System.Collections.Generic;
using Core.Entities;
using HealthCareApp.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entity.Models
{
    public partial class City : IEntity
    {
        public City()
        {
            District = new HashSet<District>();
        }

        public int Id { get; set; }
        public string CityName { get; set; }

        public virtual ICollection<District> District { get; set; }
    }
}
