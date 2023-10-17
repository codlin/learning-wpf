using System;
using System.Globalization;
using System.Windows.Data;

namespace BindingToMethod;
internal class DoubleToString : IValueConverter {
    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture) => value.ToString();

    public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        if (value is string strValue) {
            var converted = double.TryParse(strValue, out double result);
            if (converted) {
                return result;
            }
        }
        return null;
    }
}
