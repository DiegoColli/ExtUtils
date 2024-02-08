namespace ExtUtils;

public static class LongExtensions
{
    public static DateTime ToUtcDateTime(this long self) => DateTimeOffset.FromUnixTimeMilliseconds(self).UtcDateTime;
}