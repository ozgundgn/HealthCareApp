using System.Collections.Generic;
using Core.Entities;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entity.Models
{
    public partial class District : IEntity
    {
        public District()
        {
            Address = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string DistrictName { get; set; }
        public int? CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Address> Address { get; set; }
    }
}
