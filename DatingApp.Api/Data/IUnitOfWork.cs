using System.Threading.Tasks;

namespace DatingApp.Api.Data
{
    public interface IUnitOfWork
    {
         Task<bool> SaveChangesAsync();
    }
}