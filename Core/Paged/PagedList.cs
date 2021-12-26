using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Paged
{
   public class PagedList<T>
    {
        public PagedList() { }
        public PagedList(List<T> list, int pageSize, int pageIndex, int totalRecord, int totalPage)
        {
            PageSize = Math.Abs(pageSize);
            PageIndex = pageIndex;
            Items = list;
            TotalRecord = totalRecord;
            TotalPage = totalPage;
        }
        public List<T> Items { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalRecord { get; set; }
        public int TotalPage { get; set; }
    }
}

