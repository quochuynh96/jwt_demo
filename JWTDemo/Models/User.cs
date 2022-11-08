using System;
using JWTDemo.Models.Enum;

namespace JWTDemo.Models
{
	public class User
	{
		public User(){}
		public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserPermissionEnum Permission { get; set; }
    }
}

