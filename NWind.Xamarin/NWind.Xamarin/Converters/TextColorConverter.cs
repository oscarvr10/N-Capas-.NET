using System;
using System.Globalization;
using Xamarin.Forms;

namespace NWind.Xamarin.Converters
{
    public class TextColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color colorBrush = Color.Transparent;

            if (value is bool hasError)
                colorBrush = hasError ? Color.Red : Color.ForestGreen;

            return colorBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
