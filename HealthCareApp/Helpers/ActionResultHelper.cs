using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Paged;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareApp.Helpers
{
    public class ActionResultHelper
    {
        public static JsonResult GridStoreLoad<T>(PagedList<T> list)
        {
            var total = list.TotalRecord;
            var records = list.Items.ToList();
            return new JsonResult(new { records, total });
        }
    }
}
