using System;
using Entity.Models;
using Microsoft.EntityFrameworkCore.Internal;
using Repository.Abstract;
using Repository.Concrete;
using Service.Abstract;
using Service.Concrete;
using Xunit;

namespace TestService
{
    public class TestUserService
    {
        private readonly IUserService _userService;
        public TestUserService()
        {
            _userService = new UserService(new UserRepository());
        }
        [Fact]
        public void UserLoginResult()
        {
            Assert.True(_userService.Login("yasemin@gmail.com", "1234").Success);
        }
        [Fact]
        public void UserAddResult()
        {
            Assert.True(!_userService.Add(new User()).Success);
        }
    
        [Fact]
        public void UserUpdateResult()
        {
            Assert.True(!_userService.Update(new User()).Success);
        }
        [Fact]
        public void UserIdentityNumberControlResult()
        {
            Assert.True(_userService.UserIdentityNumberControl("24928480614"));
        }
        [Fact]

        public void SendMailToUserResult()
        {
            Assert.True(!_userService.SendMailToUser("Deneme Maili",0).Success);
        }
        [Fact]
        public void GetUserAddressResult()
        {
            Assert.True(_userService.GetUserAddress(1).Success);
        }
        [Fact]
        public void GetCityListResult()
        {
            Assert.True(_userService.GetCityList().Data.Any());
        }
        [Fact]
        public void GetDistrictListResult()
        {
            Assert.True(_userService.GetDistrictList(1).Data.Any());
        }
    }
}
