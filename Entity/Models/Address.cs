using Core.Entities;
using HealthCareApp.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entity.Models
{
    public partial class Address:IEntity
    {
        public int Id { get; set; }
        public string AddressDesc { get; set; }
        public int? CityId { get; set; }
        public int? DistrictId { get; set; }
        public int UserId { get; set; }

        public virtual District District { get; set; }
        public virtual HealthCareApp.Models.User User { get; set; }
    }
}
