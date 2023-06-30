public class Model
{
  public long IdUser { get; set; }
  public string? Name { get; set; }
  public bool IsActive { get; set; }
}

public class GetUserListResponse
{
  public List<Model> Users { get; set; }
}