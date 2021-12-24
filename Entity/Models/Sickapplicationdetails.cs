using System;
using Core.Entities;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entity.Models
{
    public partial class SickApplicationDetails : IEntity
    {
        public int Id { get; set; }
        public DateTime? SicknessDate { get; set; }
        public string SicknessDetail { get; set; }
        public int? ApplicationId { get; set; }

        public virtual Application Application { get; set; }
    }
}
