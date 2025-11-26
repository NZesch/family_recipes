using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[ApiController]
[Route("household")]
public class HouseholdController : ControllerBase
{
    private readonly ILogger<HouseholdController> _logger;
    private PgContext _db;

    public HouseholdController(ILogger<HouseholdController> logger, PgContext db)
    {
        _logger = logger;
        _db = db;
    }

    [HttpGet()]
    public async Task<ActionResult<List<HouseholdReadDto>>> GetHouseholds()
    {
        return await _db.Households
            .Select(h => new HouseholdReadDto
            {
                Id = h.Id,
                Name = h.Name
            }).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<HouseholdReadDto>> GetHouseholdById(Guid id)
    {
        Household? household = await _db.Households.FindAsync(id);
        if (household is null)
        {
            return NotFound();
        }

        return new HouseholdReadDto
        {
            Id = household.Id,
            Name = household.Name
        };
    }

    [HttpPost()]
    public async Task<ActionResult<HouseholdReadDto>> AddHousehold(HouseholdCreateDto householdCreateDto)
    {
        Household household = new Household
        {
            Id = Guid.NewGuid(),
            Name = householdCreateDto.Name,
        };

        await _db.Households.AddAsync(household);
        await _db.SaveChangesAsync();

        return new HouseholdReadDto
        {
            Id = household.Id,
            Name = household.Name
        };
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<HouseholdReadDto>> UpdateHouseholdById(Guid id, HouseholdUpdateDto householdUpdateDto)
    {
        Household? household = await _db.Households.FindAsync(id);
        if (household is null)
        {
            return NotFound();
        }

        household.Name = householdUpdateDto.Name;
        await _db.SaveChangesAsync();

        return new HouseholdReadDto
        {
            Id = household.Id,
            Name = household.Name
        };
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteHouseholdById(Guid id)
    {
        Household? household = _db.Households.Find(id);
        if (household is not null)
        {
            _db.Households.Remove(household);
            await _db.SaveChangesAsync();
        }

        return Ok();
    }
}