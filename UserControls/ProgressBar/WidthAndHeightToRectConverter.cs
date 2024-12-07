using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CustomProgressBar
{
    public class WidthAndHeightToRectConverter : IMultiValueConverter
    {
        public object Convert(
            object[] values,
            Type targetType,
            object parameter,
            CultureInfo culture
        )
        {
            double width = values[0] is double v0 ? v0 : 0;
            double height = values[1] is double v1 ? v1 : 0;
            return new Rect(0, 0, width, height);
        }

        public object[] ConvertBack(
            object value,
            Type[] targetTypes,
            object parameter,
            System.Globalization.CultureInfo culture
        )
        {
            throw new NotImplementedException();
        }
    }
}
