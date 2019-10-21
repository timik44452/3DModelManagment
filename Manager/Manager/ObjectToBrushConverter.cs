using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Manager
{
    public class ObjectToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                return GetBrush((bool)value);
            }

            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        private Brush GetBrush(bool value)
        {
            return new SolidColorBrush(value ? Colors.Green : Colors.Red);
        }
    }
}
