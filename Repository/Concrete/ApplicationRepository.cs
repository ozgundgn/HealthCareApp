using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Models.Application;
using Repository.Abstract;
using Repository.Helpers;

namespace Repository.Concrete
{
    public class ApplicationRepository : EntityRepositoryBase<HealtyCareContext, Application>, IApplicationRepository
    {
        public List<SickApplicationListModel> GetSickApplicationList()
        {
            
            using (HealtyCareContext context = new HealtyCareContext())
            {
             var  sickDetailList=  context.Applications
                    .Include(favoriteGenre => favoriteGenre.User)
                    .Include(genre => genre.SickApplicationDetails).Select(x=>new SickApplicationListModel()
                    {
                        Mail=x.User.Mail,
                        Name = x.User.FirstName,
                        Surname = x.User.LastName,
                        Phone=x.User.Phone,
                        TransferType = x.TransferType,
                        Description=x.Description,
                        SicknesskDate = x.SickApplicationDetails.ToList()[0].SicknessDate

                    }).ToList();
             return sickDetailList;
            }
        }
        public List<DonorApplicationListModel> GetDonorApplicationList()
        {

            using (HealtyCareContext context = new HealtyCareContext())
            {
                var sickDetailList = context.Applications
                    .Include(favoriteGenre => favoriteGenre.User)
                    .Select(x => new DonorApplicationListModel()
                    {
                        Mail = x.User.Mail,
                        Name = x.User.FirstName,
                        Surname = x.User.LastName,
                        Phone = x.User.Phone,
                        TransferType = x.TransferType,
                    }).ToList();
                return sickDetailList;
            }
        }
        public List<Question> GetQuestionList()
        {

            using (HealtyCareContext context = new HealtyCareContext())
            {
                var questionList = context.Questions.Where(x=>x.UserType==Convert.ToInt32(SessionHelper.DefaultSession.UserType))
                   .ToList();
                return questionList;
            }
        }
        public Application SetApplication(ApplicationSaveRequestModel model)
        {
            var list = new List<QuestionResult>();
            foreach (var item in model.QuestionResultList)
            {
                    var question = new QuestionResult(){QuestionId = item.QuestionId, Result = item.QuestionResult};
                list.Add(question);
            }
            using (HealtyCareContext context = new HealtyCareContext())
            {
                var application = context.Applications.Add(new Application
                {
                    RelativesName = model.RelativesName,
                    RelativeSurname = model.RelativesSurname,
                    RelativesPhone = model.RelativesPhone,
                    UserId = SessionHelper.DefaultSession.Id,
                    TransferType = SessionHelper.DefaultSession.UserType,
                    Statu = 1,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    QuestionResult = list,
                    SickApplicationDetails = new List<SickApplicationDetails>
                        {new SickApplicationDetails {SicknessDate = model.SickDate, SicknessDetail = model.SickDesc}},
                    Report = new List<Report> {new Report {ReportName = model.ReportName } }


                }).Entity;
                var id=context.SaveChanges();
                return application;
            }
        }
    }
}
