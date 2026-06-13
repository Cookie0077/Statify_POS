using System.Globalization;
using System.Windows.Data;

namespace Statify.Converters
{
    public class MsToDurationConverter : IValueConverter
    {
        public static string Convert(int totalMs)
        {
            int totalSeconds = totalMs / 1000;
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;
            return $"{minutes}:{seconds:D2}";
        }

        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int || value is double)
                return Convert(System.Convert.ToInt32(value));
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}