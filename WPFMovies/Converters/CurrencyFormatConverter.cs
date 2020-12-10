using System;
using System.CodeDom;
using System.Globalization;
using System.Windows.Data;

namespace WPFMovies.Converters
{
    public class CurrencyFormatConverter: IValueConverter
    {
        private static readonly CultureInfo Culture = new CultureInfo("en-US");

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is ulong))
                throw new ArgumentNullException();
            return string.Format(Culture, "{0:C}", value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
