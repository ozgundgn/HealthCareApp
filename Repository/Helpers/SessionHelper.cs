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
        public static IRedisClient _redisClient;
        static SessionHelper()
        {
            _redisClient = new RedisClient("37.247.104.251?db=10");
        }
        public static void Configure(IHttpContextAccessor accessor)
        {
            current = accessor;

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



