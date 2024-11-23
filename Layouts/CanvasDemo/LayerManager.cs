using System.Collections.Generic;
using System.Windows.Media;

namespace CanvasDemo
{
    internal class LayerManager
    {
        readonly List<Layer> _layers = new();

        public void Add(Layer layer)
        {
            _layers.Add(layer);
        }

        public void Draw(DrawingContext dc)
        {
            foreach (Layer layer in _layers)
            {
                layer.Draw(dc);
            }
        }
    }
}
