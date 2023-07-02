namespace RecruitApi.Controllers.Extensions
{
  public static class EnumExtensions
  {
    public static TEnum FindEnumValueById<TEnum>(int id) where TEnum : struct, Enum
    {
      if (!typeof(TEnum).IsEnum)
      {
        throw new ArgumentException("TEnum must be an enumerated type.");
      }

      foreach (TEnum value in Enum.GetValues(typeof(TEnum)))
      {
        if (Convert.ToInt32(value) == id)
        {
          return value;
        }
      }
      return default(TEnum);
    }
  }
}