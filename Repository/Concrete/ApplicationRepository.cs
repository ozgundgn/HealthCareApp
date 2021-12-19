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
                       .Include(genre => genre.SickApplicationDetails).Select(x => new SickApplicationListModel()
                       {
                           Mail = x.User.Mail,
                           Name = x.User.FirstName,
                           Surname = x.User.LastName,
                           Phone = x.User.Phone,
                           TransferType = x.TransferType,
                           Description = x.Description,
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
                var questionList = context.Questions.Where(x => x.UserType == Convert.ToInt32(SessionHelper.DefaultSession.UserType))
                   .ToList();
                return questionList;
            }
        }
        public List<UserApplicationListModel> GetUserApplicationInformList()
        {
            using (HealtyCareContext context = new HealtyCareContext())
            {
                var appList = context.Applications.Include(app => app.User).Where(x => x.UserId == Convert.ToInt32(SessionHelper.DefaultSession.Id)).Select(m => new UserApplicationListModel()
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
    }
}
