using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity.Models;
using Models.Application;
using Models.Enums;
using Repository.Abstract;
using Repository.Concrete;
using Repository.Helpers;
using Service.Abstract;
using Service.Concrete;
using Xunit;

namespace TestService
{
    public class TestApplicationService
    {
        private readonly IApplicationService _applicationService;
        public TestApplicationService()
        {
            _applicationService = new ApplicationService(new ApplicationRepository());
        }

        [Fact]
        public void GetSickApplicationListResultForNullValue()
        {
            var result = _applicationService.GetSickApplicationList(null);
            Assert.True(!result.Success);
        }

        [Fact]
        public void GetSickApplicationListResultForRealValue()
        {
            SickAplicationRequestModel model = new SickAplicationRequestModel()
            {
                Status = 1,
                Page = 1,
                Limit = 1
            };
            var result = _applicationService.GetSickApplicationList(model);
            Assert.True(result.Data.Items.Any());
        }
        [Fact]
        public void GetDonorApplicationListResultForNullValue()
        {
            var result = _applicationService.GetSickApplicationList(null);
            Assert.True(!result.Success);
        }

        [Fact]
        public void GetDonorApplicationListResultForRealValue()
        {
            DonorAplicationRequestModel model = new DonorAplicationRequestModel() { Status = 2,Page = 1,Limit = 1};
            var result = _applicationService.GetDonorApplicationList(model);
            Assert.True(result.Data.Items.Any());
        }
        [Fact]
        public void GetQuestionListResult()
        {
            var result = _applicationService.GetQuestionList();
            Assert.True(result.Data.Any());
        }

        [Fact]
        public void SetApplicationResultForNull()
        {
            var result = _applicationService.SetApplicationState(null);
            Assert.True(!result.Success);
        }
        [Fact]
        public void SetApplicationResultForRealValue()
        {
            ApplicationSaveRequestModel model = new ApplicationSaveRequestModel()
            {
                RelativesName = "Hakan",
                RelativesSurname = "Yanar",
                RelativesPhone = "50664916469",
                QuestionResultList = new List<QuestionResultList>()
                {
                    new QuestionResultList()
                    {
                        QuestionId=1,
                        QuestionResult = 1
                    }
                },
                ReportName = "rapor",
                SickDate = DateTime.Now.Date,
                SickDesc = "Kan değerlerinin normalin altında seyretmesi.",
                TransferType = (int)TransferType.BloodTransfer
            };
            var result = _applicationService.SetApplicationState(null);
            Assert.True(result.Success);
        }
        [Fact]
        public void SetApplicationStateResultForNull()
        {
            var result = _applicationService.SetApplicationState(null);
            Assert.True(!result.Success);
        }
        [Fact]
        public void SetApplicationStateResultForRealValue()
        {
            StateSaveRequestModel model = new StateSaveRequestModel() { UserId = 1, AppId = 1, Description = "Test için yapılan açıklamadır.", PlatformType = 1 };
            var result = _applicationService.SetApplicationState(model);
            Assert.True(result.Success);
        }
        [Fact]
        public void SetDonorUserMachForNull()
        {
            var result = _applicationService.SetDonorUserMach(null);
            Assert.True(!result.Success);
        }
        [Fact]
        public void SetDonorUserMachForRealValue()
        {
            DonorUserMachRequestModel requestmodel = new DonorUserMachRequestModel();
            requestmodel.DonorUserId = 2;
            requestmodel.DonorAppId = 2;
            requestmodel.UserAppId = 1;
            var result = _applicationService.SetDonorUserMach(requestmodel);
            Assert.True(result.Success);
        }

        [Fact]
        public void GetUserApplicationInformListForNull()
        {
            var result = _applicationService.GetUserApplicationInformList(null);
            Assert.True(!result.Success);
        }
        [Fact]
        public void GetUserApplicationInformListForRealValue()
        {
            UserAplicationRequestModel model = new UserAplicationRequestModel()
            {
                Filter = "kan",
                Status = 1,
                Direction = "asc",
                Limit = 20,
                Page=30
            };
            var result = _applicationService.GetUserApplicationInformList(model);
            Assert.True(result.Success);
        }
        [Fact]
        public void GetByIdForZero()
        {
            var result = _applicationService.GetById(0);
            Assert.True(!result.Success);
        }
        [Fact]
        public void GetByIdForRealValue()
        {
            var result = _applicationService.GetById(1);
            Assert.True(result.Success);
        }

    }
}
