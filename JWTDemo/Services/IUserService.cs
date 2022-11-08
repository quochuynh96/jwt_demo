using System;
using JWTDemo.Models.Request;

namespace JWTDemo.Services
{
    public interface IUserService
    {
        Task<bool> LoginAsync(LoginRequestModel request);
    }
}

