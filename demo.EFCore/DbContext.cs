using demo.webapi.demo.Models;
using Microsoft.EntityFrameworkCore;

namespace demo.webapi.demo.EFCore
{
    public class DemoDbContext:DbContext
    {

        public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options)
        {

        }
        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Helper.ConnectionString);
            }
        }
    }
}
