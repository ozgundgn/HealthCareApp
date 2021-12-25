using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Paged;
using Core.Utilities.Results;
using Entity.Models;
using Models.Application;

namespace Repository.Abstract
{
    public interface IApplicationRepository : IEntityRepository<Application>
    {
        PagedList<SickApplicationListModel> GetSickApplicationList(SickAplicationRequestModel model);
        PagedList<DonorApplicationListModel> GetDonorApplicationList(DonorAplicationRequestModel model);
        List<Question> GetQuestionList();

        Application SetApplication(ApplicationSaveRequestModel model);
        bool SetApplicationState(StateSaveRequestModel model);
        bool SetDonorUserMach(UserApplicationMatch model);


        PagedList<UserApplicationModel> GetUserApplicationInformList(UserAplicationRequestModel model);

        List<City> GetCityList();
        List<District> GetDistrictList(int id);
    }
}
