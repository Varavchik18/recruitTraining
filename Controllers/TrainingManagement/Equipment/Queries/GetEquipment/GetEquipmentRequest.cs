//request model for get equipment

using MediatR;


public class GetEquipmentRequest : IRequest<GetEquipmentResponse>
{
  public int IdEquipment { get; set; }
}
