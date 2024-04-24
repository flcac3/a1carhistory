using Microsoft.EntityFrameworkCore;
using userinfo.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    { }
    public DbSet<Garage> Garages { get; set; }
    public DbSet<Servicelog> Servicelogs { get; set; }
}