using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HealthCareApp.Models
{
    public partial class Question
    {
        public Question()
        {
            Questionresult = new HashSet<Questionresult>();
        }

        public int Id { get; set; }
        public string Questiondesc { get; set; }
        public int? Usertype { get; set; }

        public virtual ICollection<Questionresult> Questionresult { get; set; }
    }
}
