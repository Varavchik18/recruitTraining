public class GetEquipmentResponse
{
  public string Name { get; set; }
  public int Weight { get; set; }
  public EquipmentTypeEnum EquipmentType { get; set; }
  public string Description { get; set; }
  public string ImageUrl { get; set; }
  public string VideoUrl { get; set; }
  public int Count { get; set; }
  public bool isForHomeWorkout { get; set; }
  public bool isForOutdoorWorkout { get; set; }
  public string Notes { get; set; }
}

