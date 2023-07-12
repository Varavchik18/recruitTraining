using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RecruitApi.Models;
using RecruitApi.Models.Training;

public class Progress
{
  [Key]
  public int ProgressId { get; set; }

  [Required]
  public int UserId { get; set; }

  [Required]
  public int ExerciseId { get; set; }

  [Required]
  public DateTime Date { get; set; }

  public int Sets { get; set; }
  public int Repetitions { get; set; }
  public int Weight { get; set; }

  // Navigation property for User
  [ForeignKey("UserId")]
  public User User { get; set; }

  // Navigation property for Exercise
  [ForeignKey("ExerciseId")]
  public Exercise Exercise { get; set; }
}