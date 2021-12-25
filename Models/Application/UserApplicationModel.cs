using System;
using System.Collections.Generic;
using System.Text;
using Entity.Models;
using ServiceStack;

namespace Models.Application
{
    public class UserApplicationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? ApplicationDateTime { get; set; }
        public string Description { get; set; }
        public string RelativesName { get; set; }
        public string RelativesSurname { get; set; }
        public string RelativesPhone { get; set; }
        public int? Statu { get; set; }
        public DateTime? UpdateDateTime { get; set; }
        public int? TransferType { get; set; }
        public DateTime? SicknessDate { get; set; }
        public List<QuestionResult> QuestionResulList { get; set; }
        public int? SicknessDetailId { get; set; }
    }
}
