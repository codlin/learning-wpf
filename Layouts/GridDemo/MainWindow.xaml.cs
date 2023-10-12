using System.Windows;

namespace GridDemo {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void AvgRowColGrid(object sender, RoutedEventArgs e) {
            AvgGridRowColWindow window = new();
            window.Owner = this;
            window.Show();
        }

        private void DivByContent(object sender, RoutedEventArgs e) {
            AutoGridRowColWindow window = new();
            window.Owner = this;
            window.Show();
        }

        private void FixColRow(object sender, RoutedEventArgs e) {
            GridFixRowColWindow window = new GridFixRowColWindow();
            window.Owner = this;
            window.Show();
        }
    }
}
