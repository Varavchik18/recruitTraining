using AutoMapper;
using MediatR;
using RecruitApi.Models;

public class GetUserQueryHandler : IRequestHandler<GetUserRequest, GetUserResponse>
{
  private readonly ISystemDbContext _appDbContext;
  private readonly IMapper _mapper;
  public GetUserQueryHandler(ISystemDbContext appDbContext,
  IMapper mapper)
  {
    _appDbContext = appDbContext;
    _mapper = mapper;
  }
  public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
  {
    if (_appDbContext.Users == null || _appDbContext.Users.Count() == 0)
    {
      throw new NotFoundException(nameof(User), request.IdUser);
    }
    var user = await _appDbContext.Users.FindAsync(request.IdUser);

    if (user == null)
    {
      throw new NotFoundException(nameof(User), request.IdUser);
    }
    var response = _mapper.Map<GetUserResponse>(user);

    return response;
  }
}