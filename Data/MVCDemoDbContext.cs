using ASPFILM.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ASPFILM.Data
{
    public class MVCDemoDbContext : DbContext
    {
        public MVCDemoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Film> Films { get; set; }
    }
}
