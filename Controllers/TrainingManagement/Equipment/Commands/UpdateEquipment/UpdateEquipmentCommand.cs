using MediatR;

public class UpdateEquipmentCommand : IRequest<int>
{
  public int IdEquipment { get; set; }
  public int Weight { get; set; }
  public string Name { get; set; }
  public int EquipmentTypeId { get; set; }
  public string? Description { get; set; }
  public string? ImageUrl { get; set; }
  public string? VideoUrl { get; set; }
  public int? Count { get; set; }
  public bool isForHomeWorkout { get; set; }
  public bool isForOutdoorWorkout { get; set; }
  public string? Notes { get; set; }
}

public class UpdateEquipmentCommandHandler : IRequestHandler<UpdateEquipmentCommand, int>
{
  private readonly ISystemDbContext _context;

  public UpdateEquipmentCommandHandler(ISystemDbContext context)
  {
    _context = context;
  }

  public async Task<int> Handle(UpdateEquipmentCommand request, CancellationToken cancellationToken)
  {
    ArgumentNullException.ThrowIfNullOrEmpty(request.Name, "Equipment name cannot be null or empty");

    var equipment = await _context.Equipments.FindAsync(request.IdEquipment);

    if (equipment == null)
    {
      throw new NotFoundException(nameof(equipment), request.IdEquipment);
    }


    var equipmentType = EquipmentTypeEnum.None;
    if (request.EquipmentTypeId != null && Enum.IsDefined(typeof(EquipmentTypeEnum), request.EquipmentTypeId))
    {
      equipmentType = (EquipmentTypeEnum)request.EquipmentTypeId;
    }

    equipment.Update(
      name: request.Name,
      weight: request.Weight,
      description: request.Description,
      imageUrl: request.ImageUrl,
      videoUrl: request.VideoUrl,
      notes: request.Notes,
      count: request.Count ?? 0,
      equipmentType: equipmentType
    );

    await _context.SaveToDbAsync();

    return equipment.IdEquipment;
  }
}