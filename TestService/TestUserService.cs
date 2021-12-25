using System;
using Repository.Abstract;
using Repository.Concrete;
using Service.Concrete;
using Xunit;

namespace TestService
{
    public class TestUserService
    {
       
        [Fact]
        public void Test1()
        {
            UserService _services=new UserService(new UserRepository());
            var aa=_services.Login("gfh@hotmail.com", "1234");
            Assert.Equal(false,aa.Success);

        }
    }
}
