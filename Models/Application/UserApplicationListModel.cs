using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Application
{
    public class UserApplicationListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? ApplicationDateTime { get; set; }
        public string Description { get; set; }
        public string RelativesName { get; set; }
        public int? Statu { get; set; }
        public DateTime? UpdateDateTime { get; set; }
        public int? TransferType { get; set; }
    }
}
