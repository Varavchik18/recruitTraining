using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitApi.Models;

namespace RecruitApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly AppDbContext _context;
    private readonly IMediator _mediator;

    public UsersController(AppDbContext context, IMediator mediator)
    {
      _context = context;
      _mediator = mediator;
    }

    [HttpGet("users")]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetUserList()
    {
      if (_context.Users == null)
      {
        return NotFound();
      }
      return await _context.Users
          .Select(x => Extensions.ItemToDTO(x))
          .ToListAsync();
    }

    [HttpGet("user/{id}")]
    public async Task<ActionResult<GetUserResponse>> GetUserById([FromRoute] long id)
    {
      try
      {
        var result = await _mediator.Send(new GetUserRequest { IdUser = id });
        return result;
      }
      catch (NotFoundException ex)
      {
        return NotFound(ex.Message);
      }
    }

    [HttpPut("{id}/update")]
    public async Task<IActionResult> UpdateUser([FromRoute] long id, [FromBody] UserDTO user)
    {
      if (id != user.IdUser)
      {
        return BadRequest();
      }

      _context.Entry(user).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!userExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    [HttpPost("create")]
    public async Task<ActionResult<User>> CreateUser([FromBody] UserDTO user)
    {
      _context.Users.Add(new User(user.Name, user.IsActive));
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(GetUserById), new { id = user.IdUser }, user);
    }

    [HttpDelete("{id}/delete")]
    public async Task<IActionResult> DeleteUser([FromRoute] long id)
    {
      if (_context.Users == null)
      {
        return NotFound();
      }
      var user = await _context.Users.FindAsync(id);
      if (user == null)
      {
        return NotFound();
      }
      else if (user.IsActive)
      {
        return UnprocessableEntity($"Unable to delete active user. {nameof(User)} is active: {user.IsActive}");
      }
      else
      {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
      }

      return NoContent();
    }

    private bool userExists(long id)
    {
      return (_context.Users?.Any(e => e.IdUser == id)).GetValueOrDefault();
    }
  }
}
