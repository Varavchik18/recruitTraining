using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RecruitApi.Models;

public class NutritionPlan
{
  [Key]
  public int PlanId { get; set; }

  [Required]
  public int UserId { get; set; }

  [Required]
  public string Name { get; set; }

  public string Description { get; set; }

  [Required]
  public DateTime StartDate { get; set; }

  [Required]
  public DateTime EndDate { get; set; }

  // Navigation property for User
  [ForeignKey("UserId")]
  public User User { get; set; }

  // Navigation property for NutritionPlanItems
  public ICollection<NutritionPlanItem> NutritionPlanItems { get; set; }
}