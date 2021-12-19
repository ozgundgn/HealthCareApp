using System;
using System.Linq;
using Core.DataAccess.EntityFramework;
using Entity.Models;
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
    }
}
