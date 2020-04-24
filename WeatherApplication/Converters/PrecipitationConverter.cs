using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WeatherApplication.Converters
{
    public class PrecipitationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool hasPrecipitation = (bool)value;
            if (hasPrecipitation)
                return "Raining";
            return "Not Raining";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string precipitationText = (string)value;
            if (precipitationText == "Raining")
                return true;
            return false;
        }
    }
}
