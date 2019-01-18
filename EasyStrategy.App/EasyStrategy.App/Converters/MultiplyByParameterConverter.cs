using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace EasyStrategy.App.Converters
{
    public class MultiplyByParameterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (double.TryParse(value?.ToString(), out double _value))
            {
                if (double.TryParse(parameter?.ToString(), out double multiply))
                {
                    return _value * multiply;
                }
                else
                {
                    throw new InvalidCastException();
                }
            }
            else
            {
                throw new InvalidCastException();
            }
            
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
