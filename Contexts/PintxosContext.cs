using Microsoft.EntityFrameworkCore;

namespace BlazorPintxos;

public class PintxosContext : DbContext
{
    public PintxosContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Contest> Contests { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Pintxo> Pintxos { get; set; }
    public DbSet<Vote> Votes { get; set; }
}