using System;
using System.Collections.Generic;
using Core.Entities;
using HealthCareApp.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entity.Models
{
    public partial class Application:IEntity
    {
        public Application()
        {
            QuestionResult = new HashSet<QuestionResult>();
            Report = new HashSet<Report>();
            SickApplicationDetails = new HashSet<SickApplicationDetails>();
            UserApplicationMatchApplicationDonor = new HashSet<UserApplicationMatch>();
            UserApplicationMatchApplicationSick = new HashSet<UserApplicationMatch>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string RelativesPhone { get; set; }
        public int? TransferType { get; set; }
        public string RelativesName { get; set; }
        public string RelativeSurname { get; set; }
        public string Description { get; set; }
        public int? Statu { get; set; }
        public string CancellationReason { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual HealthCareApp.Models.User User { get; set; }
        public virtual ICollection<QuestionResult> QuestionResult { get; set; }
        public virtual ICollection<Report> Report { get; set; }
        public virtual ICollection<SickApplicationDetails> SickApplicationDetails { get; set; }
        public virtual ICollection<UserApplicationMatch> UserApplicationMatchApplicationDonor { get; set; }
        public virtual ICollection<UserApplicationMatch> UserApplicationMatchApplicationSick { get; set; }
    }
}
