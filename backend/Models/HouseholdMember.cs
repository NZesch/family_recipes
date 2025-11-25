namespace backend.Models;

public class HouseholdMember
{
    public Guid UserId { get; set; }
    public Guid HouseholdId { get; set; }
    public User User { get; set; } = null!;
    public Household Household { get; set; } = null!;
}