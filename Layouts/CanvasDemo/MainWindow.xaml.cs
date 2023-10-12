using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CanvasDemo {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void DisplayCanvas(object sender, RoutedEventArgs e) {
            DrawCanvas();
        }

        private void DrawCanvas() {
            Window window = new();
            window.Title = "Canvas Sample";

            // create canvas
            Canvas canvas = new();
            canvas.Width = 600;
            canvas.Height = 400;
            canvas.Background = new SolidColorBrush(Colors.LightSkyBlue);

            // create rectangle
            Rectangle rect = new() {
                Fill = new SolidColorBrush(Colors.DeepSkyBlue),
                Width = 250,
                Height = 150
            };
            // set dependency properties
            //rect.SetValue(Canvas.TopProperty, (double)100);
            Canvas.SetTop(rect, 100);
            rect.SetValue(Canvas.LeftProperty, (double)100);
            canvas.Children.Add(rect);

            // create circle
            Ellipse ellipse = new() {
                Fill = new SolidColorBrush(Colors.White),
                Width = 50,
                Height = 50
            };
            Canvas.SetTop(ellipse, 125);
            Canvas.SetLeft(ellipse, 125);
            canvas.Children.Add(ellipse);


            window.Content = canvas;
            window.Owner = this;
            window.Show();
        }
    }
}
