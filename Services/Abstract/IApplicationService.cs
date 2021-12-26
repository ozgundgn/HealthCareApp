using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Paged;
using Core.Utilities.Results;
using Entity.Models;
using Models.Application;

namespace Service.Abstract
{
    public interface IApplicationService
    {
        IDataResult<PagedList<SickApplicationListModel>> GetSickApplicationList(SickAplicationRequestModel model);
        IDataResult<PagedList<DonorApplicationListModel>> GetDonorApplicationList(DonorAplicationRequestModel model);
        IDataResult<IndexChartReturnModel> GetIndexChartData();
        IDataResult<List<Question>> GetQuestionList();
        IDataResult<Application> SetApplication(ApplicationSaveRequestModel model);
        IResult SetApplicationState(StateSaveRequestModel model);
        IResult SetDonorUserMach(DonorUserMachRequestModel model);
        IDataResult<PagedList<UserApplicationModel>> GetUserApplicationInformList(UserAplicationRequestModel model);
        
        IDataResult<ApplicationCreateViewModel> GetById(int applicationId);

    }
}
