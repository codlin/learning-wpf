using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace ValueConverterFormatStrings;

class ImagePathConverter : IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        string? path = value as string;
        if (path == null) {
            //throw new ArgumentNullException("path was invalid");
            return Binding.DoNothing;
        }
        return new Uri(Path.Combine(Directory.GetCurrentDirectory(), path));
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        throw new NotImplementedException();
    }
}
