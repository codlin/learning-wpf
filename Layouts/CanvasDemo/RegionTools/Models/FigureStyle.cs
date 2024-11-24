using System.Windows.Media;

namespace CanvasDemo.RegionTools.Models
{
    public class FigureStyle
    {
        public Brush BorderBrush { get; set; } = Brushes.Blue;
        public double BorderThickness { get; set; } = 1;
        public Brush Fill { get; set; } = Brushes.Blue;
        public double FillOpacity { get; set; } = 0.5;

        public FigureStyle Clone()
        {
            return new FigureStyle
            {
                BorderBrush = BorderBrush,
                BorderThickness = BorderThickness,
                Fill = Fill,
                FillOpacity = FillOpacity
            };
        }
    }
}
