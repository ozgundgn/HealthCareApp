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
        public IDataResult<SickApplicationListModel> GetSickApplicationList()
        {
            using (HealtyCareContext context = new HealtyCareContext())
            {
                var a = context.Applications;
             var  aaaa=  context.Applications
                    .Include(favoriteGenre => favoriteGenre.User)
                    .Include(genre => genre.SickApplicationDetails)
                    .ToList();
            }

            return null;
        }
    }
}
