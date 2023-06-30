using RecruitApi.Models;

public class Extensions
{
  public static UserDTO ItemToDTO(User user) =>
      new UserDTO
      {
        IdUser = user.IdUser,
        Name = user.Name,
        IsActive = user.IsActive
      };
}