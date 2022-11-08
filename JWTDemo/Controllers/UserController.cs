using System;
using JWTDemo.Models.Request;
using JWTDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace JWTDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService userService { get; set; }
        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        [HttpPost(Name = "Login")]
        public async Task<ActionResult> Login([FromBody]LoginRequestModel request)
        {
            var result = await userService.Login(request);
            return Ok(result);
        }
    }
}

