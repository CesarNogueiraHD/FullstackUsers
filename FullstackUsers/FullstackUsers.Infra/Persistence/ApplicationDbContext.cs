using FullstackUsers.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FullstackUsers.Infra.Persistence
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<UserEntity> Users { get; set; }
    }
}
