using System;
using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Abstract;
using Repository.Helpers;

namespace Repository.Concrete
{
    public class UserRepository : EntityRepositoryBase<HealtyCareContext, User>, IUserRepository
    {
        public bool SendMail(string message, string emailTo)
        {
            MailHelper mailHelper = new MailHelper("ornekgmail.com", "orneksifre", true);
            return mailHelper.Send(emailTo, message);
        }
        public Address GetUserAddress(int userid)
        {
			      using (HealtyCareContext context = new HealtyCareContext())
			      {
				        return  context.Addresses.Include(x => x.User).Where(x => x.UserId == userid).FirstOrDefault();
					  }
				}
  }
}
