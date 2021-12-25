using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.Paged;
using Core.Utilities.Results;
using Entity.Models;
using Models.Application;
using Repository.Abstract;
using Repository.Helpers;
using Service.Abstract;
using ServiceStack;

namespace Service.Concrete
{
    public class ApplicationService : IApplicationService
    {
        private IApplicationRepository _applicationRepository;
        public ApplicationService(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public IDataResult<List<SickApplicationListModel>> GetSickApplicationList()
        {
            var sickList = _applicationRepository.GetSickApplicationList();
            return new SuccessDataResult<List<SickApplicationListModel>>(sickList);
        }
        public IDataResult<PagedList<DonorApplicationListModel>> GetDonorApplicationList(DonorAplicationRequestModel model)
        {
            var donorList = _applicationRepository.GetDonorApplicationList(model);
            return new SuccessDataResult<PagedList<DonorApplicationListModel>>(donorList);
        }
        public IDataResult<List<Question>> GetQuestionList()
        {
            var questionList = _applicationRepository.GetQuestionList();
            return new SuccessDataResult<List<Question>>(questionList);

        }
        public IDataResult<Application> SetApplication(ApplicationSaveRequestModel model)
        {
            var setapp = _applicationRepository.SetApplication(model);
            return new SuccessDataResult<Application>(setapp);
        }
        public IResult SetApplicationState(StateSaveRequestModel model)
        {
            var setapp = _applicationRepository.SetApplicationState(model);
            if (setapp)
            {
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult();
            }

        }
        public IDataResult<List<UserApplicationModel>> GetUserApplicationInformList()
        {
            var userAppList = _applicationRepository.GetUserApplicationInformList();
            return new SuccessDataResult<List<UserApplicationModel>>(userAppList);
        }

        public IDataResult<List<City>> GetCityList()
        {
            var cityList = _applicationRepository.GetCityList();
            return new SuccessDataResult<List<City>>(cityList);
        }
        public IDataResult<List<District>> GetDistrictList(int id)
        {
            var districtList = _applicationRepository.GetDistrictList(id);
            return new SuccessDataResult<List<District>>(districtList);
        }

        public IDataResult<ApplicationCreateViewModel> GetById(int applicationId)
        {
            var appData = _applicationRepository.GetUserApplicationInform(applicationId);

            var returnModel = new ApplicationCreateViewModel()
            {
                Id = appData.Id,
                ApplicationDateTime = appData.ApplicationDateTime,
                Description = appData.Description,
                Statu = appData.Statu,
                Surname = SessionHelper.DefaultSession.LastName,
                Name = SessionHelper.DefaultSession.FirstName,
                TransferType = appData.TransferType,
                RelativesName = appData.RelativesName,
                RelativesSurname = appData.RelativesSurname,
                RelativesPhone = appData.RelativesPhone,
                SicknessDate = appData.SicknessDate,
                SicknessDetailId = appData.SicknessDetailId,
                QuestionResulList = appData.QuestionResulList

            };
            return new SuccessDataResult<ApplicationCreateViewModel>(returnModel);

        }
    }
}
