using System;
using JWTDemo.Models.Request;
using JWTDemo.Utils;

namespace JWTDemo.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration configuration;
        public UserService(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public async Task<bool> LoginAsync(LoginRequestModel request)
        {
            Thread.Sleep(1000);
            if (request.Username == "admin" && AESUtils.DecryptString(request.Password, configuration["AES:key"], configuration["AES:iv"]) == "admin")
            {
                return true;
            }
            return false;
        }
    }
}

