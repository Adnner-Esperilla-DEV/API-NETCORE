
using System.Globalization;

namespace ESPERILLA.Entities.Utility;

public class DateUtility
{
    public static readonly string INPUT_FORMAT = "yyyy-MM-dd";
    public static readonly string OUTPUT_FORMAT = INPUT_FORMAT;
    public static readonly string OUTPUT_FORMAT_WITH_TIME = $"{OUTPUT_FORMAT} HH:mm:ss";

    public static DateTime? ToDateTime(string date)
    {
        bool success = DateTime.TryParseExact(
            date,
            INPUT_FORMAT,
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out DateTime result
            );
        if (success) return result;

        return null;
    }
    public static DateTime? ToDateTimeUniversalUTC(string date)
    {
        bool success = DateTime.TryParseExact(
            date,
            INPUT_FORMAT,
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out DateTime result
            );
        DateTime localDate = DateTime.ParseExact(date, OUTPUT_FORMAT, null);
        DateTime utcDate = DateTime.SpecifyKind(localDate, DateTimeKind.Unspecified).ToUniversalTime();
        if (success) return utcDate;

        return null;
    }
    public static DateOnly? ToDateOnly(string date)
    {
        bool success = DateOnly.TryParseExact(
            date,
            INPUT_FORMAT,
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out DateOnly result
            );

        if (success) return result;

        return null;
    }

    public static string ToString(DateTime date)
    {
        return date.ToString(OUTPUT_FORMAT, CultureInfo.InvariantCulture);
    }

    public static string ToString(DateOnly date)
    {
        return date.ToString(OUTPUT_FORMAT, CultureInfo.InvariantCulture);
    }

    public static string ToStringWithTime(DateTime date)
    {
        return date.ToString(OUTPUT_FORMAT_WITH_TIME, CultureInfo.InvariantCulture);
    }

    public static string ToStringWithTime(DateOnly date)
    {
        return date.ToString(OUTPUT_FORMAT_WITH_TIME, CultureInfo.InvariantCulture);
    }
    public static bool? ValidateHour(string time)
    {
        return TimeSpan.TryParseExact(time, "hh\\:mm", CultureInfo.InvariantCulture, out _);
    }
    public static bool ValidateDate(string fecha)
    {
        DateTime fechaConvertida;
        return DateTime.TryParseExact(fecha, INPUT_FORMAT,
                                      CultureInfo.InvariantCulture,
                                      DateTimeStyles.None,
                                      out fechaConvertida);
    }
}
