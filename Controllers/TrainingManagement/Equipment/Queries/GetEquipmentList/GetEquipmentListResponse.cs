public class GetEquipmentListResponse
{
  public List<EquipmentDto> EquipmentList { get; set; }
}

//equipment dto

public class EquipmentDto
{
  public string Name { get; set; }
  public int Weight { get; set; }
  public string Description { get; set; }
  public string ImageUrl { get; set; }
  public string VideoUrl { get; set; }
  public int Count { get; set; }
  public bool isForHomeWorkout { get; set; }
  public bool isForOutdoorWorkout { get; set; }
  public string Notes { get; set; }
  public EquipmentTypeEnum EquipmentType { get; set; }

}