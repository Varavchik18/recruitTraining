using System.ComponentModel.DataAnnotations;

public class MuscleGroup
{
  [Key]
  public int MuscleGroupId { get; set; }

  [Required]
  public string Name { get; set; }

  public string Description { get; set; }
}