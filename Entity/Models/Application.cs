using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HealthCareApp.Models
{
    public partial class Application
    {
        public Application()
        {
            Questionresult = new HashSet<Questionresult>();
            Report = new HashSet<Report>();
            Sickapplicationdetails = new HashSet<Sickapplicationdetails>();
            UserapplicationmatchApplicationdonor = new HashSet<Userapplicationmatch>();
            UserapplicationmatchApplicationsick = new HashSet<Userapplicationmatch>();
        }

        public int Id { get; set; }
        public int Userid { get; set; }
        public string Relativesphone { get; set; }
        public int? Transfertype { get; set; }
        public string Relativesname { get; set; }
        public string Relativesurname { get; set; }
        public string Description { get; set; }
        public int? Statu { get; set; }
        public string Cancellationreason { get; set; }
        public DateTime? Createdate { get; set; }
        public DateTime? Updatedate { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Questionresult> Questionresult { get; set; }
        public virtual ICollection<Report> Report { get; set; }
        public virtual ICollection<Sickapplicationdetails> Sickapplicationdetails { get; set; }
        public virtual ICollection<Userapplicationmatch> UserapplicationmatchApplicationdonor { get; set; }
        public virtual ICollection<Userapplicationmatch> UserapplicationmatchApplicationsick { get; set; }
    }
}
