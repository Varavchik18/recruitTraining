using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class NutritionPlanItem
{
  [Key]
  public int ItemId { get; set; }

  [Required]
  public int PlanId { get; set; }

  [Required]
  public string MealName { get; set; }

  [Required]
  public string FoodItem { get; set; }

  [Required]
  public int Quantity { get; set; }

  public int Calories { get; set; }

  // Navigation property for NutritionPlan
  [ForeignKey("PlanId")]
  public NutritionPlan NutritionPlan { get; set; }
}