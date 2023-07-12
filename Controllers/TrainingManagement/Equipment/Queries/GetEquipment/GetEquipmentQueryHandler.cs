using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RecruitApi.Models;
using RecruitApi.Models.Training;

public class GetEquipmentQueryHandler : IRequestHandler<GetEquipmentRequest, GetEquipmentResponse>
{
  private readonly SystemDbContext _context;
  private readonly IMapper _mapper;

  public GetEquipmentQueryHandler(SystemDbContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  public async Task<GetEquipmentResponse> Handle(GetEquipmentRequest request, CancellationToken cancellationToken)
  {
    if (_context.Equipments == null || _context.Equipments.Count() == 0)
    {
      throw new NotFoundException(nameof(Equipment), request.IdEquipment);
    }
    var equipment = await _context.Equipments.FindAsync(request.IdEquipment);

    if (equipment == null)
    {
      throw new NotFoundException(nameof(Equipment), request.IdEquipment);
    }
    var response = _mapper.Map<GetEquipmentResponse>(equipment);

    return response;
  }
}