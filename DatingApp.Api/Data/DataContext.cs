using DatingApp.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts):
            base(opts)
        {  }

        public DbSet<Value> Values { get; set; }
    }
}