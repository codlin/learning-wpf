using System.Windows.Media;

namespace CanvasDemo
{
    internal class FigureRectangle
    {
        double _width;
        double _height;
        double _top;
        double _left;

        public double Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public double Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public double Top
        {
            get { return _top; }
            set { _top = value; }
        }

        public double Left
        {
            get { return _left; }
            set { _left = value; }
        }

        public double Right
        {
            get { return _left + _width; }
        }

        public double Bottom
        {
            get { return _top + _height; }
        }

        public FigureRectangle(double width, double height, double top, double left)
        {
            _width = width;
            _height = height;
            _top = top;
            _left = left;
        }

        public void Draw(DrawingContext dc)
        {
            // create rectangle
            dc.DrawRectangle(Brushes.DeepSkyBlue, new Pen(Brushes.Black, 1), new System.Windows.Rect(_left, _top, _width, _height));
        }
    }
}
