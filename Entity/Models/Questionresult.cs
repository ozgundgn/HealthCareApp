using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HealthCareApp.Models
{
    public partial class Questionresult
    {
        public int Id { get; set; }
        public int? Questionid { get; set; }
        public int? Result { get; set; }
        public int? Applicationid { get; set; }

        public virtual Application Application { get; set; }
        public virtual Question Question { get; set; }
    }
}
