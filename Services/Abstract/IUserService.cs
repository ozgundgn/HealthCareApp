using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq.Expressions;
using System.Text;
using Core.Utilities.Results;
using Entity;
using Entity.Models;

namespace Service.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Update(User user);
        IDataResult<User> Login(string email, string password);
        IResult SendMailToUser(string message, int id);
        IDataResult<Address> GetUserAddress(int id);
    }
}
