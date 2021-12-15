using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Utilities.Results;
using Entity;
using Entity.Models;
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

        public IResult Add(User user)
        {
            var result = _userRepository.Add(user);
            if (result)
            {
                return new SuccessResult();
            }

            return new ErrorResult();
        }
    }
}
