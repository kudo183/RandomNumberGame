using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace RandomNumberGame
{
    class LengthValueConverter : IValueConverter
    {
        LengthConverter lengthConverter = new LengthConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return lengthConverter.ConvertFrom(null, culture, value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
