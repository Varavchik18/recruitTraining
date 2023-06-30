using MediatR;
using RecruitApi.Models;

public class CreateUserCommand : IRequest<long>
{
  public string Name { get; set; }
  public bool IsActive { get; set; }
}

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, long>
{
  private readonly IAppDbContext _context;

  public CreateUserCommandHandler(IAppDbContext context)
  {
    _context = context;
  }

  public async Task<long> Handle(CreateUserCommand request, CancellationToken cancellationToken)
  {
    if (request.Name == null || String.IsNullOrWhiteSpace(request.Name))
    {
      throw new BadRequestException("Name is required");
    }

    var newUser = new User(request.Name, request.IsActive);
    _context.Users.Add(newUser);
    await _context.SaveToDbAsync();

    return newUser.IdUser;
  }
}