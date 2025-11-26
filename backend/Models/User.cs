namespace backend.Models;

public class User
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public List<Household> Households { get; set; } = [];
    public List<HouseholdMember> HouseholdMembers { get; } = [];
}

public class UserReadDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
}

public class UserCreateDto
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
}

public class UserUpdateDto
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
}