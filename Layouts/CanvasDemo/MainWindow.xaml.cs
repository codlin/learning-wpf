using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CanvasDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LayerManagerHost _layerManagerHost;
        public MainWindow()
        {
            InitializeComponent();
            _layerManagerHost = new();
        }

        private void DisplayCanvas(object sender, RoutedEventArgs e)
        {
            DrawCanvas();
        }

        private void DrawCanvas()
        {
            Window window = new();
            window.Title = "Canvas Sample";

            // create canvas
            Canvas canvas = new();
            canvas.Width = 600;
            canvas.Height = 400;
            canvas.Background = new SolidColorBrush(Colors.LightSkyBlue);

            // create circle
            Ellipse ellipse = new()
            {
                Fill = new SolidColorBrush(Colors.White),
                Width = 300,
                Height = 300
            };
            Canvas.SetTop(ellipse, 100);
            Canvas.SetLeft(ellipse, 100);
            canvas.Children.Add(ellipse);

            canvas.Children.Add(_layerManagerHost);

            window.Content = canvas;
            window.Owner = this;
            window.Show();
        }
    }
}
