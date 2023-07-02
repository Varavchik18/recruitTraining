using MediatR;

public class DeleteEquipmentCommand : IRequest<Unit>
{
  public int IdEquipment { get; set; }
}

public class DeleteEquipmentCommandHandler : IRequestHandler<DeleteEquipmentCommand, Unit>
{
  private readonly IAppDbContext _context;

  public DeleteEquipmentCommandHandler(IAppDbContext context)
  {
    _context = context;
  }

  public async Task<Unit> Handle(DeleteEquipmentCommand request, CancellationToken cancellationToken)
  {
    var equipment = await _context.Equipments.FindAsync(request.IdEquipment);

    if (equipment == null)
    {
      throw new NotFoundException(nameof(equipment), request.IdEquipment);
    }

    _context.Equipments.Remove(equipment);
    await _context.SaveToDbAsync();

    return Unit.Value;
  }
}