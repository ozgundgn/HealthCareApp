using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Application
{
  public class StateSaveRequestModel
    {
      public int  PlatformType { get; set; }
      public int AppId { get; set; }
      public int UserId { get; set; }
      public string Description { get; set; }
            
        
    }
}
