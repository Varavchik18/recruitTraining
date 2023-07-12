using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RecruitApi.Models;

public class WorkoutSession
{
  [Key]
  public int SessionId { get; set; }

  [Required]
  public int UserId { get; set; }

  [Required]
  public int ProgramId { get; set; }

  [Required]
  public DateTime Date { get; set; }

  public int Duration { get; set; }

  // Navigation property for User
  [ForeignKey("UserId")]
  public User User { get; set; }

  // Navigation property for WorkoutProgram
  [ForeignKey("ProgramId")]
  public WorkoutProgram WorkoutProgram { get; set; }

  // Navigation property for WorkoutSessionExercises
  public ICollection<WorkoutSessionExercise> WorkoutSessionExercises { get; set; }
}