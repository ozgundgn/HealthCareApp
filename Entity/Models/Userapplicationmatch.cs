using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HealthCareApp.Models
{
    public partial class Userapplicationmatch
    {
        public int Sickuserid { get; set; }
        public int Donoruserid { get; set; }
        public int Id { get; set; }
        public int Applicationsickid { get; set; }
        public int Applicationdonorid { get; set; }
        public DateTime Matchdate { get; set; }

        public virtual Application Applicationdonor { get; set; }
        public virtual Application Applicationsick { get; set; }
        public virtual User Donoruser { get; set; }
        public virtual User Sickuser { get; set; }
    }
}
