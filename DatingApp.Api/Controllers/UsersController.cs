using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.Api.Data;
using DatingApp.Api.DTOs;
using DatingApp.Api.Helpers;
using DatingApp.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Api.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IRepository repo,
            IUserRepository userRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._repo = repo;
            this._userRepository = userRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery]UserParams userParams)
        {
            var users = await _userRepository.GetUsers(userParams);

            var usersToReturn = _mapper.Map<IEnumerable<UserForListDto>>(users);

            Response.AddPagination(users.CurrentPage,
                users.PageSize,
                users.TotalCount,
                users.TotalPages);

            return Ok(usersToReturn);
        }

        [HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = (User)await _repo.GetOneAsync<User>(filter: u => u.Id == id && u.IsDeleted == false, includeProperties: "Gender,City,Photos,City.Country");

            var userToReturn = _mapper.Map<UserDetailDto>(user);

            return Ok(userToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserForUpdateDto UserForUpdateDto)
        {
            if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();
            var userFromRepo = await _repo.GetByIdAsync<User>(id);

            _mapper.Map(UserForUpdateDto, userFromRepo);

            if (await _unitOfWork.SaveChangesAsync())
                return NoContent();

            throw new Exception($"Updating user {userFromRepo.KnownAs} failed on save");
        }
    }
}