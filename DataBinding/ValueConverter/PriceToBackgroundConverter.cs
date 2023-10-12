using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace ValueConverterFormatStrings;

class PriceToBackgroundConverter : IValueConverter {
    public decimal MinimumPriceToHighlight { get; set; }
    public Brush HighlightBrush { get; set; } = Brushes.Red;
    public Brush DefaultBrush { get; set; } = SystemColors.WindowBrush;

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        decimal price = (decimal)value;
        if (price >= MinimumPriceToHighlight) {
            return HighlightBrush;
        }
        return DefaultBrush;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        throw new NotImplementedException();
    }
}
