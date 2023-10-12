using System.Windows;

namespace DockPanelDemo {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void LastChildFillTrue(object sender, RoutedEventArgs e) {
            LastChildFillTrueWindow window = new();
            window.Owner = this;
            window.Show();
        }

        private void LastChildFillFalse(object sender, RoutedEventArgs e) {
            LastChildFillFalseWindow window = new();
            window.Owner = this;
            window.Show();
        }

        private void DockLeft(object sender, RoutedEventArgs e) {
            DockLefWindow window = new();
            window.Owner = this;
            window.Show();
        }
    }
}
