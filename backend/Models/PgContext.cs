using Microsoft.EntityFrameworkCore;

namespace backend.Models;

public class PgContext : DbContext
{
    public PgContext(DbContextOptions<PgContext> options)
        : base(options)
    { }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Household> Households { get; set; } = null!;
    public DbSet<HouseholdMember> HouseholdMembers { get; set; } = null!;
    public DbSet<Instruction> Instructions { get; set; } = null!;
    public DbSet<Recipe> Recipes { get; set; } = null!;
    public DbSet<RecipeIngredient> RecipeIngredients { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>()
            .HasMany(e => e.Households)
            .WithMany(e => e.Users)
            .UsingEntity<HouseholdMember>();
        
        builder.Entity<Household>()
            .HasIndex(h => h.Name)
            .IsUnique();

        builder.Entity<Instruction>()
            .HasIndex(i => new { i.RecipeId, i.InstructionNum })
            .IsUnique();
    }
}