using System;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Api.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public AuthRepository(DataContext context, IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._context = context;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

            if (user == null)
                return null;

            if (!Security.Security.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;


            return user;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            Security.Security.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.Users.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            return user;
        }


        public async Task<bool> UserExists(string username)
        {
            if (await _context.Users.AnyAsync(x => x.Username == username))
                return true;
            return false;
        }
    }
}