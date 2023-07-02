using AutoMapper;
using RecruitApi.Models.Training;


public class GetEquipmentMapper : Profile
{
  public GetEquipmentMapper()
  {
    CreateMap<Equipment, GetEquipmentResponse>();
  }
}
