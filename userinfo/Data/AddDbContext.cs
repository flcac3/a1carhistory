using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using userinfo.Models;

namespace userinfo.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        public DbSet<Garage> Garages { get; set; }
        public DbSet<Servicelog> Servicelogs { get; set; }
    }
}