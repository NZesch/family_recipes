namespace backend.Models;

public class User
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Password { get; set; }
    public List<Household> Households { get; set; } = [];
    public List<HouseholdMember> HouseholdMembers { get; } = [];
}

public class UserReadDto
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}

public class UserCreateDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Password { get; set; }
}

public class UserUpdateDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Password { get; set; }
}