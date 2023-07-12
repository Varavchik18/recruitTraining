using System;
using System.ComponentModel.DataAnnotations;

namespace RecruitApi.Models;

public class User
{
  [Key]
  public int UserId { get; set; }

  [Required]
  public string Name { get; set; }

  [Required]
  [EmailAddress]
  public string Email { get; set; }

  [Required]
  public string Password { get; set; }

  [Required]
  public DateTime DateOfBirth { get; set; }

  [Required]
  public string Gender { get; set; }

  public int Height { get; set; }
  public int Weight { get; set; }

  // Navigation property for Progress
  // public ICollection<Progress> Progress { get; set; }

  // // Navigation property for NutritionPlan
  // public ICollection<NutritionPlan> NutritionPlans { get; set; }
  public void Update(string name, string email, DateTime birthDate, string gender)
  {
    this.Name = name;
    this.Email = email;
    this.DateOfBirth = birthDate;
    this.Gender = gender;
  }

  public void UpdatePhysicInfo(int height, int weight)
  {
    this.Height = height;
    this.Weight = weight;
  }

  public void SetPassword(string password)
  {
    this.Password = password;
  }

  public void UpdatePassword(string oldPassword, string newPassword)
  {
    if (this.Password != oldPassword)
    {
      throw new Exception("Old password is not correct");
    }

    SetPassword(newPassword);
  }

}