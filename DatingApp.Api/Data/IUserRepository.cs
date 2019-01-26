using System.Threading.Tasks;
using DatingApp.Api.Helpers;
using DatingApp.Api.Models;

namespace DatingApp.Api.Data
{
    public interface IUserRepository
    {
         Task<PagedList<User>> GetUsers(UserParams userParams);
    }
}