using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using Entity;
using Repository.Abstract;

namespace Repository.Concrete
{
    public class EfUserRepository : EntityRepositoryBase<HealthCareDbContext, User>, IUserRepository
    {
    }
}
