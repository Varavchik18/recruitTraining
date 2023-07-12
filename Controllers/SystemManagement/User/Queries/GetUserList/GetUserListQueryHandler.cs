using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetUserListQueryHandler : IRequestHandler<GetUserListRequest, GetUserListResponse>
{
  private readonly ISystemDbContext _appDbContext;
  private readonly IMapper _mapper;
  public GetUserListQueryHandler(ISystemDbContext appDbContext,
  IMapper mapper)
  {
    _appDbContext = appDbContext;
    _mapper = mapper;
  }
  public async Task<GetUserListResponse> Handle(GetUserListRequest request, CancellationToken cancellationToken)
  {
    var response = _mapper.Map<GetUserListResponse>(_appDbContext.Users.ToListAsync());

    return response;
  }
}