

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

using Core.Entities;

namespace Entity.Models
{
    public partial class Report:IEntity
    {
        public int Id { get; set; }
        public string ReportName { get; set; }
        public int? ApplicationId { get; set; }

        public virtual Application Application { get; set; }
    }
}
