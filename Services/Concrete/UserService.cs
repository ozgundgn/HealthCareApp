using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Entity;
using Repository.Abstract;
using Service.Abstract;

namespace Service.Concrete
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

    }
}
