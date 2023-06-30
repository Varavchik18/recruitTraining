//class Exercise with following properties: Name, Description, TargetMuscle, Equipment, Difficulty, ImageUrl, VideoUrl
using System.ComponentModel.DataAnnotations;

namespace RecruitApi.Models.Training
{
  public class Exercise
  {

    public Exercise()
    {
      Equipment = new List<Equipment>();
    }

    public Exercise(int id, string name, string description, string targetMuscleGroup, int difficulty, string imageUrl, string videoUrl, int numberOfSets, int countOfExercisesToRepeat, int authorId)
    {
      IdExercise = id;
      Name = name;
      Description = description;
      TargetMuscleGroup = targetMuscleGroup;
      Difficulty = difficulty;
      ImageUrl = imageUrl;
      VideoUrl = videoUrl;
      NumberOfSets = numberOfSets;
      CountOfExercisesToRepeat = countOfExercisesToRepeat;
      AuthorId = authorId;
      Equipment = new List<Equipment>();
    }

    [Key]
    public int IdExercise { get; set; }
    [StringLength(25)]

    public string Name { get; set; }
    [StringLength(50)]

    public string? Description { get; set; }
    [StringLength(20)]

    public string? TargetMuscleGroup { get; set; }
    public List<Equipment>? Equipment { get; set; }
    public int? Difficulty { get; set; }
    public string? ImageUrl { get; set; }
    public string? VideoUrl { get; set; }
    public int? NumberOfSets { get; set; }
    public int? CountOfExercisesToRepeat { get; set; }
    public int TotalRepetitions => NumberOfSets ?? 0 * CountOfExercisesToRepeat ?? 0;
    public long? AuthorId { get; set; }
    public User Author { get; set; }

    public void UploadImageUrl(string imageUrl)
    {
      ImageUrl = imageUrl;
    }

    public void UploadVideoUrl(string videoUrl)
    {
      VideoUrl = videoUrl;
    }

    public void UpdateNameAndDescription(string name, string description)
    {
      Name = name;
      Description = description;
    }

    public void SetInfoAboutTraining(string targetMuscleGroup, int difficulty)
    {
      TargetMuscleGroup = targetMuscleGroup;
      Difficulty = difficulty;
    }

    public void UpdateNumbersForExercises(int numberOfSets, int countOfExercisesToRepeat)
    {
      NumberOfSets = numberOfSets;
      CountOfExercisesToRepeat = countOfExercisesToRepeat;
    }

    public void DefineAuthor(int authorId)
    {
      AuthorId = authorId;
    }

    public void UpdateAuthor(User author)
    {
      Author = author;
    }


    //generate a method to add Equipment to list of equipments
    //generate a method to remove Equipment from list of equipments

    public void AddEquipment(Equipment equipment)
    {
      Equipment.Add(equipment);
    }

    public void RemoveEquipment(Equipment equipment)
    {
      Equipment.Remove(equipment);
    }

  }
}