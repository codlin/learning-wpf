using System.Windows;

namespace StackPanelDemo {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void VerticalLayout(object sender, RoutedEventArgs e) {
            VerticalLayoutWindow window = new();
            window.Owner = this;
            window.Show();
        }

        private void HorizontalLayout(object sender, RoutedEventArgs e) {
            HorizontalLayoutWindow window = new();
            window.Owner = this;
            window.Show();
        }
    }
}
