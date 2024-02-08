using System.Globalization;

namespace ExtUtils;

public static class DateTimeExtensions
{
    public static string ToLoggingString(this DateTimeOffset? self)
        => self.HasValue ? self.Value.ToString("MM/dd/yyyy HH:mm:ss:fff", CultureInfo.InvariantCulture) : "null";
}