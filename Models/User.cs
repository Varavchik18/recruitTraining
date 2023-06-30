using System.ComponentModel.DataAnnotations;

namespace RecruitApi.Models;

public class User
{
  public User(string? name, bool isActive)
  {
    Name = name;
    IsActive = isActive;
  }
  [Key]
  public long IdUser { get; set; }
  public string? Name { get; set; }
  public bool IsActive { get; set; }
}