using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HealthCareApp.Models
{
    public partial class User
    {
        public User()
        {
            Address = new HashSet<Address>();
            Application = new HashSet<Application>();
            UserapplicationmatchDonoruser = new HashSet<Userapplicationmatch>();
            UserapplicationmatchSickuser = new HashSet<Userapplicationmatch>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public short? Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public string Phone { get; set; }
        public string Identitynumber { get; set; }
        public string Mothername { get; set; }
        public string Fathername { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Height { get; set; }
        public int? Bloodgroup { get; set; }
        public int? Rh { get; set; }
        public int? Civilstatus { get; set; }
        public int? Educationstatus { get; set; }
        public short? Usertype { get; set; }
        public DateTime? Createdate { get; set; }
        public DateTime? Updatedate { get; set; }
        public DateTime? Lastlogindate { get; set; }

        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Application> Application { get; set; }
        public virtual ICollection<Userapplicationmatch> UserapplicationmatchDonoruser { get; set; }
        public virtual ICollection<Userapplicationmatch> UserapplicationmatchSickuser { get; set; }
    }
}
