using MediatR;

public class UpdateUserCommand : IRequest<Unit>
{
  public long IdUser { get; set; }
  public string Name { get; set; }
}

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
{
  private readonly ISystemDbContext _context;

  public UpdateUserCommandHandler(ISystemDbContext context)
  {
    _context = context;
  }

  public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
  {
    if (request.Name == null || String.IsNullOrWhiteSpace(request.Name))
    {
      throw new BadRequestException("Name is required");
    }
    if (_context.Users == null || !_context.Users.Any())
    {
      throw new NotFoundException("No users found");
    }

    var user = await _context.Users.FindAsync(request.IdUser);
    if (user == null)
    {
      throw new NotFoundException("User not found");
    }

    user.Update(request.Name);
    await _context.SaveToDbAsync();

    return Unit.Value;
  }
}