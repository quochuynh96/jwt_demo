using System;
using System.ComponentModel.DataAnnotations;

namespace JWTDemo.Models.Request
{
    public class LoginRequestModel
    {
        public LoginRequestModel(string username, string password)
        {
            Username = username;
            Password = password;
        }

        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

