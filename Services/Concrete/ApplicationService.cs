﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entity.Models;
using Models.Application;
using Repository.Abstract;
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

        public IDataResult<List<SickApplicationListModel>> GetSickApplicationList()
        {
            var sickList = _applicationRepository.GetSickApplicationList();
            return new SuccessDataResult<List<SickApplicationListModel>>(sickList);
        }
        public IDataResult<List<DonorApplicationListModel>> GetDonorApplicationList()
        {
            var donorList = _applicationRepository.GetDonorApplicationList();
            return new SuccessDataResult<List<DonorApplicationListModel>>(donorList);
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
        public IDataResult<List<UserApplicationListModel>> GetUserApplicationInformList()
        {
            var userAppList = _applicationRepository.GetUserApplicationInformList();
            return new SuccessDataResult<List<UserApplicationListModel>>(userAppList);
        }
    }
}
