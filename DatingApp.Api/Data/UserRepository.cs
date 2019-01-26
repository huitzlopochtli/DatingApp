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
            var users = context.Users.Include(u => u.Gender).Include(u => u.Photos).Include(u => u.City).ThenInclude(c => c.Country);

            return await PagedList<User>.CreateAsync(users, userParams.PageNumber, userParams.PageSize);
        }
    }
}