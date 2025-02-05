using AppMvcArchi.Models;
using Microsoft.EntityFrameworkCore;

namespace AppMvcArchi.Data;

public class AppDbContext : DbContext
{
    private readonly IConfiguration _config;
    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration config) : base(options)
    {
        _config = config;
    }
    public DbSet<Item> Items { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
        }
    }
}
