using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetEquipmentListQueryHandler : IRequestHandler<GetEquipmentListRequest, GetEquipmentListResponse>
{
  private readonly ISystemDbContext _context;
  private readonly IMapper _mapper;

  public GetEquipmentListQueryHandler(ISystemDbContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  public async Task<GetEquipmentListResponse> Handle(GetEquipmentListRequest request, CancellationToken cancellationToken)
  {
    var equipmentList = await _context.Equipments.ToListAsync();
    var equipmentListDto = _mapper.Map<List<EquipmentDto>>(equipmentList);
    return new GetEquipmentListResponse
    {
      EquipmentList = equipmentListDto
    };
  }
}