using Core.DataAccess.EntityFramework;
using Entity.Models;

namespace Repository.Abstract
{
    public interface IUserRepository : IEntityRepository<User>
    {
        bool SendMail(string message, string email);
    }
}
