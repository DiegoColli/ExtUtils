using System.Text;

namespace ExtUtils;

public static class StringExtensions
{  
    public static bool IsNullOrEmpty(this string input) => string.IsNullOrEmpty(input);
    
    public static bool IsNullOrEmptyAfterTrim(this string input) => input.EmptyIfNullElseTrimmed().IsNullOrEmpty();
    
    public static string EmptyIfNull(this string input) => string.IsNullOrEmpty(input) ? string.Empty : input;
    
    public static string EmptyIfNullElseTrimmed(this string input) => input.EmptyIfNull().Trim();

    public static bool InvariantCultureEquals(this string input, string value) => input.Equals(value, StringComparison.InvariantCulture);
    
    public static bool InvariantCultureEqualsIgnoreCase(this string input, string value) => input.Equals(value, StringComparison.InvariantCultureIgnoreCase);

    public static string Base64Encode(this string input)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(input.EmptyIfNull());
        return Convert.ToBase64String(bytes);
    }

    public static string GetBefore(this string input, string needle)
    {
        int index = input.IndexOf(needle, StringComparison.Ordinal);
        return index > -1 ? input.Substring(0, index) : string.Empty;
    }

    public static string GetAfter(this string input, string needle)
    {
        int index = input.IndexOf(needle, StringComparison.Ordinal);
        return index > -1 ? input.Substring(index + needle.Length) : string.Empty;
    }
    
    public static string Truncate(this string input, int maxLength)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        return input.Substring(0, Math.Min(input.Length, maxLength));
    }
}