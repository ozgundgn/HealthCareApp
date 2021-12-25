using System;
using Entity.Models;
using Repository.Abstract;
using Repository.Concrete;
using Service.Concrete;
using Xunit;

namespace TestService
{
    public class TestUserService
    {
       
        [Fact]
        public void UserLoginResult()
        {
            UserService _services=new UserService(new UserRepository());
            var aa=_services.Login("gfh@hotmail.com", "1234");
            Assert.Equal(true,aa.Success);

        }
        [Fact]
        public void UserAddResult()
        {
            UserService _services = new UserService(new UserRepository());
            
            var aa = _services.Add(new User());
            Assert.Equal(true, aa.Success);

        }
    }
}
