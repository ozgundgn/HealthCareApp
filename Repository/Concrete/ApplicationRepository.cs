using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Extentions;
using Core.Paged;
using Core.Utilities.Results;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Models.Application;
using Models.Enums;
using Repository.Abstract;
using Repository.Helpers;
using ServiceStack;

namespace Repository.Concrete
{
    public class ApplicationRepository : EntityRepositoryBase<HealtyCareContext, Application>, IApplicationRepository
    {
        public List<SickApplicationListModel> GetSickApplicationList()
        {

            using (HealtyCareContext context = new HealtyCareContext())
            {
                var sickDetailList = context.Applications
                       .Include(favoriteGenre => favoriteGenre.User)
                       .Include(genre => genre.SickApplicationDetails).Where(x => x.User.UserType == 1).Select(x => new SickApplicationListModel()
                       {
                           Id = x.Id,
                           Mail = x.User.Mail,
                           Name = x.User.FirstName,
                           Surname = x.User.LastName,
                           Phone = x.User.Phone,
                           TransferType = x.TransferType,
                           Description = x.Description,
                           SicknesskDate = x.SickApplicationDetails.ToList()[0].SicknessDate,

                       }).ToList();
                return sickDetailList;
            }
        }
        public PagedList<DonorApplicationListModel> GetDonorApplicationList(DonorAplicationRequestModel model)
        {

            using (HealtyCareContext context = new HealtyCareContext())
            {

                var detailList = context.Applications
                    .Include(favoriteGenre => favoriteGenre.User)
                    .Where(x => x.User.UserType == 2);
                if (!string.IsNullOrEmpty(model.Name))
                {
                    detailList = detailList.Where(x => x.User.FirstName.Contains(model.Name) || x.User.LastName.Contains(model.Name));
                }
                var list = detailList.Skip((model.Page - 1) * model.Limit).Take(model.Limit).Select(x => new DonorApplicationListModel()
                {
                    Id = x.Id,
                    UserId = x.User.Id,
                    Mail = x.User.Mail,
                    Name = x.User.FirstName,
                    Surname = x.User.LastName,
                    Phone = x.User.Phone,
                    TransferType = x.TransferType,
                    TransferTypeString = ((TransferType)x.TransferType).GetDescription()

                }).ToList();

                var totalCount = context.Applications.Include(favoriteGenre => favoriteGenre.User).Count(x => x.User.UserType == 2);
                PagedList<DonorApplicationListModel> donorListModel = new PagedList<DonorApplicationListModel>();
                donorListModel.Items = list;
                donorListModel.PageSize = model.Limit;
                donorListModel.PageIndex = model.Page;
                donorListModel.TotalRecord = totalCount;
                donorListModel.TotalPage = totalCount / model.Limit;
                return donorListModel;
            }
        }
        public List<Question> GetQuestionList()
        {

            using (HealtyCareContext context = new HealtyCareContext())
            {
                var questionList = context.Questions.Where(x => x.UserType == Convert.ToInt32(SessionHelper.DefaultSession.UserType))
                   .ToList();
                return questionList;
            }
        }

        public List<UserApplicationModel> GetUserApplicationInformList()
        {
            using (HealtyCareContext context = new HealtyCareContext())
            {
                var appList = context.Applications.Include(app => app.User)
                    .Where(x => x.UserId == Convert.ToInt32(SessionHelper.DefaultSession.Id))
                    .Select(m => new UserApplicationModel()
                    {
                        Id = m.Id,
                        Name = m.User.FirstName,
                        Surname = m.User.LastName,
                        ApplicationDateTime = m.CreateDate,
                        Statu = m.Statu,
                        Description = m.Description,
                        RelativesName = m.RelativesName,
                        UpdateDateTime = m.UpdateDate,
                        TransferType = m.TransferType
                    })
                   .ToList();
                return appList;
            }
        }
        public UserApplicationModel GetUserApplicationInform(int applicationId)
        {
            using (HealtyCareContext context = new HealtyCareContext())
            {
                return context.Applications.Include(app => app.User).Include(app => app.QuestionResult)
                    .Where(x => x.Id == applicationId)
                    .Select(m => new UserApplicationModel()
                    {
                        Id = m.Id,
                        Name = m.User.FirstName,
                        Surname = m.User.LastName,
                        ApplicationDateTime = m.CreateDate,
                        Statu = m.Statu,
                        Description = m.SickApplicationDetails.First().SicknessDetail,
                        RelativesName = m.RelativesName,
                        UpdateDateTime = m.UpdateDate,
                        TransferType = m.TransferType,
                        RelativesPhone = m.RelativesPhone,
                        RelativesSurname = m.RelativeSurname,
                        SicknessDate = m.SickApplicationDetails.First().SicknessDate,
                        SicknessDetailId = m.SickApplicationDetails.First().Id,
                        QuestionResulList = m.QuestionResult.ToList()
                    }).FirstOrDefault();
            }
        }
        public Application SetApplication(ApplicationSaveRequestModel model)
        {
            var list = new List<QuestionResult>();

            foreach (var item in model.QuestionResultList)
            {
                var question = new QuestionResult() { QuestionId = item.QuestionId, Result = item.QuestionResult, ApplicationId = model.Id };
                if (item.Id != 0)
                {
                    question.Id = item.Id;
                }
                list.Add(question);
            }

            var sicknessDetail =
                new SickApplicationDetails
                { SicknessDate = model.SickDate, SicknessDetail = model.SickDesc };
            if (model.SicknessDetailId != null)
            {
                sicknessDetail.Id = model.SicknessDetailId.Value;
            }

            var userApplication = new Application()
            {
                RelativesName = model.RelativesName,
                RelativeSurname = model.RelativesSurname,
                RelativesPhone = model.RelativesPhone,
                UserId = SessionHelper.DefaultSession.Id,
                TransferType = model.TransferType,
                Statu = 1,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                QuestionResult = list,
                SickApplicationDetails = new List<SickApplicationDetails>(){ sicknessDetail },
                Report = new List<Report> { new Report { ReportName = model.ReportName } }
            };

            if (model.Id == null || model.Id==0)
            {
                Add(userApplication);
            }
            else
            {
                userApplication.Id = model.Id.Value;
                Update(userApplication);
            }

            return userApplication;

        }

        public List<City> GetCityList()
        {
            using (HealtyCareContext context = new HealtyCareContext())
            {
                var cityList = context.Cities.Select(x => new City()
                {
                    Id = x.Id,
                    CityName = x.CityName,
                    District = x.District
                })
                   .ToList();
                return cityList;
            }
        }


        public List<District> GetDistrictList(int id)
        {
            using (HealtyCareContext context = new HealtyCareContext())
            {
                var districtList = context.Districts.Where(x => x.CityId == id).ToList();
                return districtList;
            }
        }
        public bool SetApplicationState(StateSaveRequestModel model)
        {
            using (HealtyCareContext context = new HealtyCareContext())
            {
                var app = Get(x => x.Id == model.AppId).FirstOrDefault();

                app.Id = model.AppId;
                app.CancellationReason = model.PlatformType == 0 ? "" : model.Description;
                app.Statu = model.PlatformType;
                app.UserId = SessionHelper.DefaultSession.Id;

                var application = Update(app);

                var id = context.SaveChanges();
                return application;
            }
        }
    }
}
