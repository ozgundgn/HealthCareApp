using System;
using Core.Entities;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entity.Models
{
    public partial class UserApplicationMatch : IEntity
    {
        public int SickUserId { get; set; }
        public int DonorUserId { get; set; }
        public int Id { get; set; }
        public int ApplicationSickId { get; set; }
        public int ApplicationDonorId { get; set; }
        public DateTime MatchDate { get; set; }

        public virtual Application ApplicationDonor { get; set; }
        public virtual Application ApplicationSick { get; set; }
        public virtual User DonorUser { get; set; }
        public virtual User SickUser { get; set; }
    }
}
