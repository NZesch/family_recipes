namespace backend.Models.Entities;

public class Instruction
{
    public Guid Id { get; set; }
    public int InstructionNum { get; set; }
    public required string Details { get; set; }
    public Guid RecipeId { get; set; }
    public Recipe Recipe { get; set; } = null!;
}