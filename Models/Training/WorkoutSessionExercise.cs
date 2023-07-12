using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RecruitApi.Models.Training;

public class WorkoutSessionExercise
{
  [Key]
  public int SessionExerciseId { get; set; }

  [Required]
  public int SessionId { get; set; }

  [Required]
  public int ExerciseId { get; set; }

  public int Sets { get; set; }
  public int Repetitions { get; set; }
  public int Weight { get; set; }

  // Navigation property for WorkoutSession
  [ForeignKey("SessionId")]
  public WorkoutSession WorkoutSession { get; set; }

  // Navigation property for Exercise
  [ForeignKey("ExerciseId")]
  public Exercise Exercise { get; set; }
}