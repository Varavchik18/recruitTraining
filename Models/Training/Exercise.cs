using System.ComponentModel.DataAnnotations;

namespace RecruitApi.Models.Training
{
  public class Exercise
  {
    [Key]
    public int ExerciseId { get; set; }

    [Required]
    public string Name { get; set; }

    public string Description { get; set; }
    public string DifficultyLevel { get; set; }
    public EquipmentTypeEnum EquipmentRequired { get; set; }

    // Navigation property for WorkoutSessionExercises
    public ICollection<WorkoutSessionExercise> WorkoutSessionExercises { get; set; }


  }
}