using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetUserListQueryHandler : IRequestHandler<GetUserListRequest, GetUserListResponse>
{
  private readonly IAppDbContext _appDbContext;
  private readonly IMapper _mapper;
  public GetUserListQueryHandler(IAppDbContext appDbContext,
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