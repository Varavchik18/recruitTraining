using AutoMapper;
using RecruitApi.Models;

public class GetUserMapper : Profile
{
  public GetUserMapper()
  {
    CreateMap<User, GetUserResponse>();
    CreateMap<UserDTO, GetUserResponse>();
  }
}