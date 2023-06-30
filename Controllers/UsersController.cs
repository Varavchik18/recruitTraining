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
    public async Task<ActionResult<GetUserListResponse>> GetUserList()
    {
      var result = await _mediator.Send(new GetUserListRequest());
      return result;
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
    public async Task<IActionResult> UpdateUser([FromRoute] long id, [FromBody] UpdateUserCommand command)
    {
      command.IdUser = id;
      try
      {
        await _mediator.Send(command);
      }
      catch (NotFoundException ex)
      {
        return NotFound(ex.Message);
      }
      catch (BadRequestException ex)
      {
        return BadRequest(ex.Message);
      }

      return NoContent();
    }

    [HttpPost("create")]
    public async Task<ActionResult<User>> CreateUser([FromBody] CreateUserCommand command)
    {
      try
      {
        var result = await _mediator.Send(new CreateUserCommand { Name = command.Name, IsActive = command.IsActive });
        return CreatedAtAction(nameof(GetUserById), new { id = result }, result);
      }
      catch (BadRequestException ex)
      {
        return BadRequest(ex.Message);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpDelete("{id}/delete")]
    public async Task<IActionResult> DeleteUser([FromRoute] long id)
    {
      try
      {
        await _mediator.Send(new DeleteUserCommand { IdUser = id });
      }
      catch (NotFoundException ex)
      {
        return NotFound(ex.Message);
      }
      catch (BadRequestException ex)
      {
        return BadRequest(ex.Message);
      }

      return NoContent();
    }
  }
}
