public class UserModel
{
  public long IdUser { get; set; }
  public string? Name { get; set; }
  public bool IsActive { get; set; }
}

public class GetUserListResponse
{
  public List<UserModel> Users { get; set; }
}