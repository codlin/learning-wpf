using System;
using System.Globalization;
using System.Windows.Data;

namespace ValueConverterFormatStrings;

[ValueConversion(typeof(decimal), typeof(string))]
class PriceConverter : IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        decimal price = (decimal)value;
        return price.ToString("C", culture);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        string? price = value as string;

        //decimal result;
        if (decimal.TryParse(price, NumberStyles.Any, culture, out decimal result)) {
            return result;
        }
        return value;
    }
}
