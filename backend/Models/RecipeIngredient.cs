namespace backend.Models.Entities;

public class RecipeIngredient
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Quantity { get; set; }
    public Guid RecipeId { get; set; }
    public Recipe Recipe { get; set; } = null!;
}