using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace StockManagement.Converters
{
    public class BackGroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool inStock = (bool)value;

            if (!inStock)
                return Brushes.LightGray;

            return Brushes.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
