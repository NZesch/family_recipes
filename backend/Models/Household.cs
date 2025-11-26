namespace backend.Models;

public class Household
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public List<User> Users { get; set; } = [];
    public List<HouseholdMember> HouseholdMembers { get; } = [];
    public List<Recipe> Recipes { get; } = new List<Recipe>();
}

public class HouseholdReadDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}

public class HouseholdCreateDto
{
    public required string Name { get; set; }
}

public class HouseholdUpdateDto
{
    public required string Name { get; set; }
}