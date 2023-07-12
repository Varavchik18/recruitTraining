using System.ComponentModel.DataAnnotations;
using RecruitApi.Models.Training;

public class WorkoutProgram
{
  [Key]
  public int ProgramId { get; set; }

  [Required]
  public string Name { get; set; }

  public string Description { get; set; }
  public int Duration { get; set; }
  public string DifficultyLevel { get; set; }
  public string TargetMuscleGroup { get; set; }

  // Navigation property for WorkoutSessions
  public ICollection<WorkoutSession> WorkoutSessions { get; set; }

}