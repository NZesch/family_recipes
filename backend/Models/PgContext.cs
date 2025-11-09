using Microsoft.EntityFrameworkCore;

namespace backend.Models;

public class PgContext : DbContext
{
    public PgContext(DbContextOptions<PgContext> options)
        : base(options)
    { }

    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Household>()
            .HasIndex(h => h.Name)
            .IsUnique();

        builder.Entity<Instruction>()
            .HasIndex(i => new { i.RecipeId, i.InstructionNum })
            .IsUnique();
    }
}