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
    }
}
