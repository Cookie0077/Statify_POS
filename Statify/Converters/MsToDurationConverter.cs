using System.Globalization;
using System.Windows.Data;

namespace Statify.Converters
{
    public class MsToDurationConverter : IValueConverter
    /* prompt: Where is the best location to parse our Duration in ms into Minutes?
        1. Before saving in the DB
        2. In the backend code in the get requests
        3. In the frontend code
        
        Gave me this Converter which I can use in Bindings
     */
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
            =>  new object();
    }
}