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
        public IDataResult<PagedList<SickApplicationListModel>> GetSickApplicationList(SickAplicationRequestModel model)
        {
            if (model == null)
            {
                return new ErrorDataResult<PagedList<SickApplicationListModel>>();
            }
            var sickList = _applicationRepository.GetSickApplicationList(model);
            return new SuccessDataResult<PagedList<SickApplicationListModel>>(sickList);
        }
        public IDataResult<PagedList<DonorApplicationListModel>> GetDonorApplicationList(DonorAplicationRequestModel model)
        {
            if (model == null)
            {
                return new ErrorDataResult<PagedList<DonorApplicationListModel>>();
            }
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
            if (model == null)
                return new ErrorDataResult<Application>();

            var setapp = _applicationRepository.SetApplication(model);
            return new SuccessDataResult<Application>(setapp);
        }
        public IResult SetApplicationState(StateSaveRequestModel model)
        {
            if (model == null)
                return new ErrorResult();

            model.UserId = SessionHelper.DefaultSession.Id;
            bool setapp = _applicationRepository.SetApplicationState(model);

            if (setapp)
                return new SuccessResult();
            else
                return new ErrorResult();

        }
        public IResult SetDonorUserMach(DonorUserMachRequestModel model)
        {
            if (model == null)
                return new ErrorResult();

            UserApplicationMatch requestmodel = new UserApplicationMatch();
            requestmodel.DonorUserId = model.DonorUserId;
            requestmodel.ApplicationDonorId = model.DonorAppId;
            requestmodel.SickUserId = SessionHelper.DefaultSession.Id;
            requestmodel.ApplicationSickId = model.UserAppId;
            requestmodel.MatchDate = DateTime.Now;
            var setapp = _applicationRepository.SetDonorUserMach(requestmodel);

            StateSaveRequestModel donormodel = new StateSaveRequestModel();
            donormodel.AppId = model.DonorAppId;
            donormodel.PlatformType = 2;
            donormodel.UserId = model.DonorUserId;
            var setdonorApp = _applicationRepository.SetApplicationState(donormodel);


            if (setapp)
                return new SuccessResult();
            else
                return new ErrorResult();
        }

        public IDataResult<PagedList<UserApplicationModel>> GetUserApplicationInformList(UserAplicationRequestModel model)
        {
            if (model == null)
                return new ErrorDataResult<PagedList<UserApplicationModel>>();

            var userAppList = _applicationRepository.GetUserApplicationInformList(model);
            return new SuccessDataResult<PagedList<UserApplicationModel>>(userAppList);
        }

        public IDataResult<ApplicationCreateViewModel> GetById(int applicationId)
        {
            if (applicationId == 0)
                return new ErrorDataResult<ApplicationCreateViewModel>();

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
