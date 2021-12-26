using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Application
{
   public class IndexChartReturnModel
    {
        public DonorAppStatusList DonorAppStatus { get; set; }
        public SickAppStatusList SickAppStatus { get; set; }
        public int DonorAppCount { get; set; }
        public int SickAppCount { get; set; }
    }

   public class DonorAppStatusList
   {
       public int Bekliyor { get; set; }
       public int Iptal { get; set; }
       public int BuPlatformdanBulundu { get; set; }
   }
   public class SickAppStatusList
   {
       public int Bekliyor { get; set; }
       public int Iptal { get; set; }
       public int BuPlatformdanBulundu { get; set; }
       public int BaskaPlatformdanBulundu { get; set; }
   }
}
