using Core.DataAccess.EntityFramework;
using Entity.Models;
using Repository.Abstract;

namespace Repository.Concrete
{
    public class UserRepository : EntityRepositoryBase<HealtyCareContext, User>, IUserRepository
    {
    }
}
