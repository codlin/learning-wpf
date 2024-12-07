using System.Windows;
using System.Windows.Media;

using CanvasDemo.RegionTools.Models;

namespace CanvasDemo.RegionTools
{
    public class FigureRegionRectVisual : FrameworkElement
    {
        public FigureRegionRect Figure { get; }

        public FigureRegionRectVisual(FigureRegionRect figure)
        {
            Figure = figure;
        }

        protected override void OnRender(DrawingContext dc)
        {
            Draw(dc);
        }

        void Draw(DrawingContext dc)
        {
            // 根据 FigureRegionRect 的 FigureStyle 绘制矩形，需要应用透明度 FillOpacity
            var style = Figure.Style;

            var rect = new Rect(new Point(Figure.Left, Figure.Top), new Point(Figure.Right, Figure.Bottom));
            var pen = new Pen(style.BorderBrush, style.BorderThickness);
            style.Fill.Opacity = style.FillOpacity;
            dc.DrawRectangle(style.Fill, pen, rect);
        }
    }
}
