using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace NWind.WPF.Converters
{
    public class TextColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Brush colorBrush = Brushes.Transparent;

            if (value is bool hasError)
                colorBrush = hasError ? Brushes.Red : Brushes.ForestGreen;

            return colorBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
