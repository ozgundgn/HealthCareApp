using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Enums;

namespace HealthCareApp.Models
{
    public class SickApplicationListViewModel
    {
        public IEnumerable<TransferType> TransferTypeEnumList { get; set; }
    }
}
