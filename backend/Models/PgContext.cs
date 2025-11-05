using Microsoft.EntityFrameworkCore;

namespace backend.Models;

public class PgContext : DbContext
{
    public PgContext(DbContextOptions<PgContext> options)
        : base(options)
    { }

    public DbSet<User> Users { get; set; } = null!;
}