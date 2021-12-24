using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Application
{
    public class SickAplicationRequestModel : BaseSearchModel
    {
        public string Filter { get; set; }
        public int TransferType { get; set; }
    }
}
