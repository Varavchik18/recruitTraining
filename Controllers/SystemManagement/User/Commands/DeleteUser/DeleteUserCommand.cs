using MediatR;
using RecruitApi.Models;

public class DeleteUserCommand : IRequest<Unit>
{
  public long IdUser { get; set; }
}


public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
{
  private readonly ISystemDbContext _context;

  public DeleteUserCommandHandler(ISystemDbContext context)
  {
    _context = context;
  }

  public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
  {
    if (_context.Users == null || !_context.Users.Any())
    {
      throw new NotFoundException("No users found");
    }

    var user = await _context.Users.FindAsync(request.IdUser);
    if (user == null)
    {
      throw new NotFoundException("User not found");
    }
    else if (user.IsActive)
    {
      throw new BadRequestException($"Unable to delete active user. {nameof(User)} is active: {user.IsActive}");
    }

    _context.Users.Remove(user);
    await _context.SaveToDbAsync();

    return Unit.Value;
  }
}