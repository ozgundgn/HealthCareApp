using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HealthCareApp.Models
{
    public partial class Sickapplicationdetails
    {
        public int Id { get; set; }
        public DateTime? Sicknessdate { get; set; }
        public string Sicknessdetail { get; set; }
        public int? Applicationid { get; set; }

        public virtual Application Application { get; set; }
    }
}
