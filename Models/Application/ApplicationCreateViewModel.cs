using System;
using System.Collections.Generic;
using System.Text;
using Entity.Models;
using Models.Enums;

namespace Models.Application
{
    public class ApplicationCreateViewModel: UserApplicationModel
    {
        public List<Question> QuestionsList { get; set; }
        public List<TransferType> TransferTypeEnumList { get; set; }
     
    }
}
