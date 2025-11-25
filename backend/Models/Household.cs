namespace backend.Models;

public class Household
{
    public Guid id { get; set; }
    public required string Name { get; set; }
    public List<User> Users { get; set; } = [];
    public List<HouseholdMember> HouseholdMembers { get; } = [];
    public ICollection<Recipe> Recipes { get; } = new List<Recipe>(); 
}