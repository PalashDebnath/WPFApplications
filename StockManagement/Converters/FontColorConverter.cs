using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace StockManagement.Converters
{
    public class FontColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal price = (decimal)value;

            if (price >= 75)
                return Brushes.DarkRed;
            else if (price >= 50 && price < 75)
                return Brushes.Red;
            else if (price >= 25 && price < 50)
                return Brushes.DarkOrange;
            else
                return Brushes.Green;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
