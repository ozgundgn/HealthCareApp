using System;
using System.Collections.Generic;
using System.Text;
using Core.Paged;
using Core.Utilities.Results;
using Entity.Models;
using Models.Application;
using Repository.Abstract;
using Repository.Helpers;
using Service.Abstract;

namespace Service.Concrete
{
    public class ApplicationService : IApplicationService
    {
        private IApplicationRepository _applicationRepository;
        public ApplicationService(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public IDataResult<PagedList<SickApplicationListModel>> GetSickApplicationList(SickAplicationRequestModel model)
        {
            var sickList = _applicationRepository.GetSickApplicationList(model);
            return new SuccessDataResult<PagedList<SickApplicationListModel>>(sickList);
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
         
                model.UserId = SessionHelper.DefaultSession.Id;


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
        public IResult SetDonorUserMach(DonorUserMachRequestModel model)
        {
            UserApplicationMatch requestmodel=new UserApplicationMatch();
            requestmodel.DonorUserId = model.DonorUserId;
            requestmodel.ApplicationDonorId = model.DonorAppId;
            requestmodel.SickUserId = SessionHelper.DefaultSession.Id;
            requestmodel.ApplicationSickId = model.UserAppId;
            requestmodel.MatchDate=DateTime.Now;
            var setapp = _applicationRepository.SetDonorUserMach(requestmodel);

            StateSaveRequestModel donormodel=new StateSaveRequestModel();
            donormodel.AppId = model.DonorAppId;
            donormodel.PlatformType = 2;
            donormodel.UserId = model.DonorUserId;
            var setdonorApp = _applicationRepository.SetApplicationState(donormodel);


            if (setapp)
            {
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult();
            }
        }
        
        public IDataResult<PagedList<UserApplicationModel>> GetUserApplicationInformList(UserAplicationRequestModel model)
        {
            var userAppList = _applicationRepository.GetUserApplicationInformList(model);
            return new SuccessDataResult<PagedList<UserApplicationModel>>(userAppList);
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

    }
}
