// mapper for get equipment list 

using AutoMapper;
using RecruitApi.Models.Training;

public class GetEquipmentListMapper : Profile
{
  public GetEquipmentListMapper()
  {
    CreateMap<Equipment, EquipmentDto>();
  }
}