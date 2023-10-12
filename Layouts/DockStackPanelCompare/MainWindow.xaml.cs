using System.Windows;

namespace DockStackPanelCompare {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void ShowDemo(object sender, RoutedEventArgs e) {
            PanelCompareWindow window = new();
            window.Show();
        }
    }
}
