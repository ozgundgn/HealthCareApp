using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Application
{
  public class DonorUserMachRequestModel
    {
      public int DonorUserId { get; set; }
      public int DonorAppId { get; set; }
      public int UserAppId { get; set; }
    }
}
