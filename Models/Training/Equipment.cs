using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitApi.Models.Training
{
  public class Equipment
  {
    [Key]
    public int IdEquipment { get; set; }

    [StringLength(20)]
    public string Name { get; set; }

    public int Weight { get; set; }
    [Column(TypeName = "int")]
    public EquipmentTypeEnum EquipmentType { get; set; }

    [StringLength(50)]
    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public string? VideoUrl { get; set; }

    public int Count { get; set; }

    public bool isForHomeWorkout { get; set; }

    public bool isForOutdoorWorkout { get; set; }

    [StringLength(100)]
    public string? Notes { get; set; }

    public Equipment(string name, int weight, string description, string imageUrl, string videoUrl, int count,
    bool isForHomeWorkout, bool isForOutdoorWorkout, string notes, EquipmentTypeEnum equipmentType)
    {
      Name = name;
      Weight = weight;
      EquipmentType = EquipmentTypeEnum.None;
      Description = description;
      ImageUrl = imageUrl;
      VideoUrl = videoUrl;
      Count = count;
      this.isForHomeWorkout = isForHomeWorkout;
      this.isForOutdoorWorkout = isForOutdoorWorkout;
      Notes = notes;
      EquipmentType = equipmentType;
    }

    //update method
    public void Update(string name, int weight, string description, string imageUrl, string videoUrl, int count, string notes, EquipmentTypeEnum equipmentType)
    {
      Name = name;
      EquipmentType = equipmentType;
      Weight = weight;
      Description = description;
      ImageUrl = imageUrl;
      VideoUrl = videoUrl;
      Count = count;
      Notes = notes;
    }

    public void UpdateNameAndDescription(string name, string description)
    {
      Name = name;
      Description = description;
    }

    public void UploadImageUrl(string imageUrl)
    {
      ImageUrl = imageUrl;
    }

    public void UploadVideoUrl(string videoUrl)
    {
      VideoUrl = videoUrl;
    }

    public void UpdateNotes(string notes)
    {
      Notes = notes;
    }

    public void UpdateWeightAndType(int weight)
    {
      Weight = weight;
      // Type = type;
    }

    public void UpdateIsForHomeWorkout(bool isForHomeWorkout)
    {
      this.isForHomeWorkout = isForHomeWorkout;
    }

    public void UpdateIsForOutdoorWorkout(bool isForOutdoorWorkout)
    {
      this.isForOutdoorWorkout = isForOutdoorWorkout;
    }
  }
}