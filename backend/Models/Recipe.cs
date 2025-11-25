namespace backend.Models;

public class Recipe
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public int PrepTime { get; set; }
    public int CookTime { get; set; }
    public int PeopleServed { get; set; }
    public required string AddedBy { get; set; }
    public Guid HouseholdId { get; set; }
    public Household Household { get; set; } = null!;
    public ICollection<Instruction> Instructions { get; } = new List<Instruction>();
    public ICollection<RecipeIngredient> RecipeIngredients { get; } = new List<RecipeIngredient>();
}