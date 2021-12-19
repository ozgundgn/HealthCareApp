using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Models.Application
{
   public class ApplicationSaveRequestModel
    {
        public byte[] ReportResultByte { get; set; }
        public IFormFile ReportResult { get; set; }
        public string TransferType { get; set; }
        public string RelativesName { get; set; }
        public string RelativesSurname { get; set; }
        public string RelativesPhone { get; set; }
        public string SickDate { get; set; }
        public string SickDesc { get; set; }
        public string QuestionResultListString { get; set; }
        public List<QuestionResultList> QuestionResultList { get; set; }
   
    }
   public class QuestionResultList
   {
       public string QuestionId { get; set; }
       public string QuestionResult { get; set; }
    }
}
