using System;
using System.Globalization;
using System.Windows.Data;

namespace MultiBinding;

internal class NameConverter : IMultiValueConverter {
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
        string name = (string)parameter switch {
            "FormatLastFirst" => values[1] + ", " + values[0],
            _ => values[0] + " " + values[1],
        };
        return name;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
        var splitValues = ((string)value).Split(' ');
        return splitValues;
    }
}

