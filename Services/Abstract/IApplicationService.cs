using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entity.Models;
using Models.Application;

namespace Service.Abstract
{
    public interface IApplicationService
    {
        IDataResult<List<SickApplicationListModel>> GetSickApplicationList();
        IDataResult<List<DonorApplicationListModel>> GetDonorApplicationList();
        IDataResult<List<Question>> GetQuestionList();
        IDataResult<Application> SetApplication(ApplicationSaveRequestModel model);
        IResult SetApplicationState(StateSaveRequestModel model);
        IDataResult<List<UserApplicationListModel>> GetUserApplicationInformList();
    }
}
