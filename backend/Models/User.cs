namespace backend.Models;

public class User
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public List<Household> Households { get; set; } = [];
    public List<HouseholdMember> HouseholdMembers { get; } = [];
}