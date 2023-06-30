using System.ComponentModel.DataAnnotations;
using RecruitApi.Models.Training;

public class TrainingProgram
{
  public TrainingProgram(string name, string description, int duration, int difficulty, List<Exercise> exercises, MuscleGroupEnum muscleGroup, string imageUrl, string videoUrl, string notes)
  {
    Name = name;
    Description = description;
    Duration = duration;
    Difficulty = difficulty;
    Exercises = exercises;
    MuscleGroup = muscleGroup;
    ImageUrl = imageUrl;
    VideoUrl = videoUrl;
    Notes = notes;
  }

  [Key]
  public int IdTrainingProgram { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public int Duration { get; set; }
  public int Difficulty { get; set; }
  public List<Exercise> Exercises { get; set; }
  public MuscleGroupEnum MuscleGroup { get; set; }
  public TrainingTypeEnum TrainingType { get; set; }
  public string ImageUrl { get; set; }
  public string VideoUrl { get; set; }
  public string Notes { get; set; }

}