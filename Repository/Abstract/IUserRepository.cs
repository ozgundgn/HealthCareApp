using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using Entity;

namespace Repository.Abstract
{
    public interface IUserRepository : IEntityRepository<User>
    {

    }
}
