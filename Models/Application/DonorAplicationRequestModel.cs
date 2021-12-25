using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Application
{
    public class DonorAplicationRequestModel : BaseSearchModel
    {
        public string Filter { get; set; }
        public int TransferType { get; set; }
        public int Status { get; set; }
    }
}
