using System.ComponentModel;

namespace LightButtonDemo
{
    internal class LightViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // 外灯带左上颜色值
        private string _outerLightStripTopLeftColor = "#FFD3D3D3";
        public string OuterLightStripTopLeftColor
        {
            get => _outerLightStripTopLeftColor;
            set
            {
                _outerLightStripTopLeftColor = value;
                OnPropertyChanged(nameof(OuterLightStripTopLeftColor));
            }
        }
    }
}
