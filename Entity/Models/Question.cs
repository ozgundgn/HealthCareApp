using System.Collections.Generic;
using Core.Entities;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entity.Models
{
    public partial class Question:IEntity
    {
        public Question()
        {
            QuestionResult = new HashSet<QuestionResult>();
        }

        public int Id { get; set; }
        public string QuestionDesc { get; set; }
        public int? UserType { get; set; }

        public virtual ICollection<QuestionResult> QuestionResult { get; set; }
    }
}
