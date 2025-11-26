using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private PgContext _db;

    public UserController(ILogger<UserController> logger, PgContext db)
    {
        _logger = logger;
        _db = db;
    }

    [HttpPost()]
    public async Task<ActionResult<UserReadDto>> AddUser(UserCreateDto userCreateDto)
    {
        User user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = userCreateDto.FirstName,
            LastName = userCreateDto.LastName,
            Password = userCreateDto.Password
        };

        await _db.Users.AddAsync(user);
        await _db.SaveChangesAsync();

        var userReadDto = new UserReadDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName
        };

        return userReadDto;
    }

    [HttpGet("/{id}")]
    public async Task<ActionResult<UserReadDto>> GetUserById(Guid id)
    {
        User? user = await _db.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
        if (user == null)
        {
            return NotFound();
        }

        var userReadDto = new UserReadDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName
        };

        return userReadDto;
    }

    [HttpGet()]
    public async Task<ActionResult<List<UserReadDto>>> GetUsers()
    {
        List<UserReadDto> users = await _db.Users
            .Select(u => new UserReadDto
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName
            })
            .ToListAsync();

        return users;
    }

    [HttpPut("/{id}")]
    public async Task<ActionResult<UserReadDto>> UpdateUser(Guid id, UserUpdateDto userUpdateDto)
    {
        User? user = await _db.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
        if (user == null)
        {
            return NotFound();
        }

        // update the user
        user.FirstName = userUpdateDto.FirstName;
        user.LastName = userUpdateDto.LastName;
        user.Password = userUpdateDto.Password ?? user.Password;

        var userReadDto = new UserReadDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName
        };

        await _db.SaveChangesAsync();

        return userReadDto;
    }

    [HttpDelete("/{id}")]
    public async Task<ActionResult> DeleteUser(Guid id)
    {
        User? user = await _db.Users.FindAsync(id);
        if (user != null)
        {
            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
        }

        return Ok();
    }
}
