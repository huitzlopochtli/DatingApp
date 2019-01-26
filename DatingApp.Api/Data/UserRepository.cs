using System;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.Api.Helpers;
using DatingApp.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Api.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext context;
        public UserRepository(DataContext context)
        {
            this.context = context;
        }
        public async Task<PagedList<User>> GetUsers(UserParams userParams)
        {
            // "Gender,Photos,City,City.Country"
            var users = context.Users.Include(u => u.Gender).Include(u => u.Photos).Include(u => u.City).ThenInclude(c => c.Country).OrderByDescending(u => u.LastActivity).AsQueryable();
            users = users.Where(u => u.Id != userParams.UserId);
            if (userParams.GenderId != null)
                users = users.Where(u => u.GenderId == userParams.GenderId);
            if (userParams.MinAge != 18 || userParams.MaxAge != 50)
            {
                var minDob = DateTime.Today.AddYears(-userParams.MaxAge - 1);
                var maxDob = DateTime.Today.AddYears(-userParams.MinAge);

                users = users.Where(u => u.DateOfBirth >= minDob && u.DateOfBirth <= maxDob);
            }

            if (!string.IsNullOrEmpty(userParams.OrderBy))
            {
                switch (userParams.OrderBy)
                {
                    case "created":
                        users = users.OrderByDescending(u => u.DateCreated);
                        break;
                    default:
                        users= users.OrderByDescending(u => u.LastActivity);
                        break;
                }
            }

                return await PagedList<User>.CreateAsync(users, userParams.PageNumber, userParams.PageSize);
            }
        }
    }