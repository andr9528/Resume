namespace Resume.Models.Extensions;

public static class StringExtensions
{
    public static string ToKey<TEnum>(this TEnum key) where TEnum : Enum
    {
        return key.ToString();
    }
}
