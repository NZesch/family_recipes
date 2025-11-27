using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[ApiController]
[Route("recipe")]
public class RecipeController : ControllerBase
{
    private readonly ILogger<RecipeController> _logger;
    private PgContext _db;

    public RecipeController(ILogger<RecipeController> logger, PgContext db)
    {
        _logger = logger;
        _db = db;
    }

    [HttpGet()]
    public async Task<ActionResult<List<RecipeReadDto>>> GetRecipes()
    {
        return await _db.Recipes
            .Select(r => new RecipeReadDto
            {
                Id = r.Id,
                AddedBy = r.AddedBy,
                Title = r.Title,
                CookTime = r.CookTime,
                HouseholdId = r.HouseholdId,
                PeopleServed = r.PeopleServed,
                PrepTime = r.PrepTime
            })
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RecipeReadDto>> GetRecipeById(Guid id)
    {
        Recipe? recipe = await _db.Recipes.FindAsync(id);

        if (recipe is null)
        {
            return NotFound();
        }

        return new RecipeReadDto
        {
            Id = recipe.Id,
            AddedBy = recipe.AddedBy,
            CookTime = recipe.CookTime,
            PrepTime = recipe.PrepTime,
            Title = recipe.Title,
            PeopleServed = recipe.PeopleServed,
            HouseholdId = recipe.HouseholdId
        };
    }

    [HttpPost()]
    public async Task<ActionResult<RecipeReadDto>> AddRecipe(RecipeCreateDto recipeCreateDto)
    {
        Recipe recipe = new Recipe
        {
            Id = Guid.NewGuid(),
            AddedBy = recipeCreateDto.AddedBy,
            CookTime = recipeCreateDto.CookTime,
            PrepTime = recipeCreateDto.PrepTime,
            Title = recipeCreateDto.Title,
            PeopleServed = recipeCreateDto.PeopleServed,
            HouseholdId = recipeCreateDto.HouseholdId
        };

        await _db.Recipes.AddAsync(recipe);
        await _db.SaveChangesAsync();

        return new RecipeReadDto
        {
            Id = recipe.Id,
            AddedBy = recipe.AddedBy,
            CookTime = recipe.CookTime,
            PrepTime = recipe.PrepTime,
            Title = recipe.Title,
            PeopleServed = recipe.PeopleServed,
            HouseholdId = recipe.HouseholdId
        };
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<RecipeReadDto>> UpdateRecipeById(Guid id, RecipeUpdateDto recipeUpdateDto)
    {
        Recipe? recipe = await _db.Recipes.FindAsync(id);

        if (recipe is null)
        {
            return NotFound();
        }

        recipe.Title = recipeUpdateDto.Title;
        recipe.PrepTime = recipeUpdateDto.PrepTime;
        recipe.CookTime = recipeUpdateDto.CookTime;
        recipe.PeopleServed = recipeUpdateDto.PeopleServed;
        recipe.HouseholdId = recipeUpdateDto.HouseholdId;

        await _db.SaveChangesAsync();

        return new RecipeReadDto
        {
            Id = recipe.Id,
            AddedBy = recipe.AddedBy,
            CookTime = recipe.CookTime,
            PrepTime = recipe.PrepTime,
            Title = recipe.Title,
            PeopleServed = recipe.PeopleServed,
            HouseholdId = recipe.HouseholdId
        };
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteRecipeById(Guid id)
    {
        Recipe? recipe = await _db.Recipes.FindAsync(id);

        if (recipe is not null)
        {
            _db.Recipes.Remove(recipe);
            await _db.SaveChangesAsync();
        }

        return Ok();
    }
}