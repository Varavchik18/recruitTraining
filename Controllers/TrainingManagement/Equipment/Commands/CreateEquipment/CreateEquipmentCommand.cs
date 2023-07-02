using AutoMapper;
using MediatR;
using RecruitApi.Models.Training;

public class CreateEquipmentCommand : IRequest<int>
{
  //properties of Equipment Model: string name, int weight, string description, string imageUrl, string videoUrl, int count,
  // bool isForHomeWorkout, bool isForOutdoorWorkout, string notes

  public string Name { get; set; }
  public int Weight { get; set; }
  public string Description { get; set; }
  public string? ImageUrl { get; set; }
  public string? VideoUrl { get; set; }
  public int? Count { get; set; }
  public bool isForHomeWorkout { get; set; }
  public bool isForOutdoorWorkout { get; set; }
  public string? Notes { get; set; }
  public int? EquipmentTypeId { get; set; }
}

public class CreateEquipmentCommandHandler : IRequestHandler<CreateEquipmentCommand, int>
{
  private readonly IAppDbContext _context;
  private readonly IMapper _mapper;

  public CreateEquipmentCommandHandler(IAppDbContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  public async Task<int> Handle(CreateEquipmentCommand request, CancellationToken cancellationToken)
  {
    if (request.Name == null || String.IsNullOrWhiteSpace(request.Name))
    {
      throw new ArgumentNullException(nameof(request.Name), "Equipment name cannot be null or empty");
    }

    var equipmentType = EquipmentTypeEnum.None;
    if (request.EquipmentTypeId != null && Enum.IsDefined(typeof(EquipmentTypeEnum), request.EquipmentTypeId))
    {
      equipmentType = (EquipmentTypeEnum)request.EquipmentTypeId;
    }

    var equipment = new Equipment(
        name: request.Name,
        weight: request.Weight,
        description: request.Description,
        imageUrl: request.ImageUrl,
        videoUrl: request.VideoUrl,
        isForHomeWorkout: request.isForHomeWorkout,
        isForOutdoorWorkout: request.isForOutdoorWorkout,
        notes: request.Notes,
        count: request.Count ?? 0,
        equipmentType: equipmentType);

    _context.Equipments.Add(equipment);
    await _context.SaveToDbAsync();

    return equipment.IdEquipment;
  }
}