namespace CanvasDemo.RegionTools.Models
{
    public class FigureRegionRect
    {
        // 几何属性
        double _top;
        double _left;
        double _width;
        double _height;

        // 关联的样式
        public FigureStyle Style { get; set; }

        public FigureRegionRect(FigureStyle style)
        {
            Style = style;
        }

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


    }
}
