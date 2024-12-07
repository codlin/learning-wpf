using System.Windows;
using System.Windows.Media;

namespace CanvasDemo
{
    internal class LayerManagerHost : FrameworkElement
    {
        readonly LayerManager _layerManager = new();

        public LayerManagerHost()
        {
            Layer layer = new();
            layer.Add(new FigureRectangle(250, 150, 100, 100));
            layer.Add(new FigureRectangle(50, 50, 125, 125));
            _layerManager.Add(layer);
        }

        protected override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);

            _layerManager.Draw(dc);
        }
    }
}
