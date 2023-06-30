using System.ComponentModel.DataAnnotations;

namespace RecruitApi.Models;

public class User
{
  [Key]
  public long IdUser { get; set; }
  public string Name { get; set; }
  public bool IsActive { get; set; }
  public User(string name, bool isActive)
  {
    Name = name;
    Enable();
  }

  public void Update(string name)
  {
    Name = name;
  }

  public void Disable()
  {
    IsActive = false;
  }

  public void Enable()
  {
    IsActive = true;
  }
}