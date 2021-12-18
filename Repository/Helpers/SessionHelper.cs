using System;
using System.Collections.Generic;
using System.Text;
using Entity.Models;
using Microsoft.AspNetCore.Http;
using ServiceStack.Redis;

namespace Repository.Helpers
{
    public static class SessionHelper
    {
        private static IHttpContextAccessor current;
        private static IRedisClient _redisClient;
      
        public static void Configure(IHttpContextAccessor accessor,IRedisClient client)
        {
            current = accessor;
            _redisClient = client;
        }
       
        public static User DefaultSession
        {
            get
            {
                if (current != null && current.HttpContext != null)
                {
                    if (current.HttpContext.Request.Cookies["user"] != null)
                    {
                        var session = _redisClient.Get<User>(string.Concat("user:", current.HttpContext.Request.Cookies["user"]));
                        if (session == null)
                        {
                            current.HttpContext.Response.Cookies.Delete("user");
                        }

                        return session ?? new User();
                    }

                }
                return new User();
            }
        }
    }
}



