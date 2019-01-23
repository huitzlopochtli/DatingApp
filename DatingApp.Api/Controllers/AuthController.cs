using System;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.Api.Data;
using DatingApp.Api.DTOs;
using DatingApp.Api.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DatingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _auth;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public AuthController(
            IAuthRepository auth,
            IUnitOfWork unitOfWork,
            IConfiguration config,
            IMapper mapper)
        {
            this._config = config;
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
            this._auth = auth;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegister)
        {
            userForRegister.Username = userForRegister.Username.ToLower();

            if (await _auth.UserExists(userForRegister.Username))
                return BadRequest("Username already exists");

            var newUser = new User
            {
                Username = userForRegister.Username
            };

            var createdUser = await _auth.Register(newUser, userForRegister.Password);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLogin)
        {
            var userFromRepo = await _auth.Login(userForLogin.Username.ToLower(), userForLogin.Password);

            if (userFromRepo == null)
                return Unauthorized();


            var token = Security.Security.GenerateLoginToken(userFromRepo, _config, _mapper);

            return Ok(token);
        }
    }
}