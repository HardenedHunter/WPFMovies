using System;
using System.Windows.Data;

namespace WPFMovies.Converters
{
    public class LessConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || parameter == null)
                return false;
            if (!Double.TryParse(value.ToString(), out var dValue) || !Double.TryParse(parameter.ToString(), out var dParameter))
                return false;
            return (dValue < dParameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}