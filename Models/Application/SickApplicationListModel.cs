using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Application
{
   public class SickApplicationListModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public int? TransferType { get; set; }
        public string Description { get; set; }
        public DateTime? SicknesskDate { get; set; }

    }
}
