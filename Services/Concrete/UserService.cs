using System;
using System.Collections.Generic;
using System.Linq;
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

        public IResult Update(User user)
        {
		      var result = _userRepository.Update(user);
		      if (result)
		      {
			      return new SuccessResult();
		      }

		      return new ErrorResult();
		    }

        public IDataResult<User> Login(string email, string password)
        {
            var result = _userRepository.Get(x => x.Mail == email && x.Password == password).FirstOrDefault();
            if (result == null)
            {
                return new DataResult<User>(null,false,"Kullanıcı girişi başarısız!");
            }

            return new DataResult<User>(result, true);
        }

        public IResult SendMailToUser(string message, int id)
        {
            var toUser = _userRepository.Get(x => x.Id == id).FirstOrDefault();
            if (toUser != null)
            {
               var response= _userRepository.SendMail(message, toUser.Mail);
               if (response)
               {
                   return new SuccessResult();
               }
            }
            return new ErrorResult();
        }   
        public IDataResult<Address> GetUserAddress(int id)
        {
		      var result = _userRepository.GetUserAddress(id);
		      return new DataResult<Address>(result, true);
				}
    }
}
