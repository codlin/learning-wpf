using System.Collections.Generic;
using System.Windows.Media;

namespace CanvasDemo
{
    internal class Layer
    {
        readonly List<FigureRectangle> _figures = new();

        public void Add(FigureRectangle figure)
        {
            _figures.Add(figure);
        }

        public void Draw(DrawingContext dc)
        {
            foreach (FigureRectangle figure in _figures)
            {
                figure.Draw(dc);
            }
        }
    }
}
