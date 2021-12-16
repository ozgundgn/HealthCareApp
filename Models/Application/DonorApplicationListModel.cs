﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Application
{
   public class DonorApplicationListModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public int? TransferType { get; set; }
    }
}
