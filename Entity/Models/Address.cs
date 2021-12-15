using System;
using System.Collections.Generic;
using Core.Entities;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HealthCareApp.Models
{
    public partial class Address:IEntity
    {
        public int Id { get; set; }
        public string Addressdesc { get; set; }
        public int? Cityid { get; set; }
        public int? Districtid { get; set; }
        public int Userid { get; set; }

        public virtual District District { get; set; }
        public virtual User User { get; set; }
    }
}
