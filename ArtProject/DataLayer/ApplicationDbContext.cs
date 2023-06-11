using ArtProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtProject.DataLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base (options)
        {
            
        }

        public DbSet<UserModel> TableUnitMaster { get; set; }
    }
}
