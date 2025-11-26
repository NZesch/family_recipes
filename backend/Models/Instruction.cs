namespace backend.Models;

public class Instruction
{
    public Guid Id { get; set; }
    public int InstructionNum { get; set; }
    public required string Details { get; set; }
    public Guid RecipeId { get; set; }
    public Recipe Recipe { get; set; } = null!;
}

public class InstructionReadDto
{
    public Guid Id { get; set; }
    public int InstructionNum { get; set; }
    public required string Details { get; set; }
    public Guid RecipeId { get; set; }
}

public class InstructionCreateDto
{
    public int InstructionNum { get; set; }
    public required string Details { get; set; }
    public Guid RecipeId { get; set; }
}

public class InstructionUpdateDto
{
    public int InstructionNum { get; set; }
    public required string Details { get; set; }
    public Guid RecipeId { get; set; }
}