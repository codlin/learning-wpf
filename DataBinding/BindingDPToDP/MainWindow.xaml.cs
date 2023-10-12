using System.Windows;

namespace BindingDPToDP {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void OnSetBgColorBtn_Click(object sender, RoutedEventArgs e) {
            SetBackgroundColorWindow window = new();
            window.Show();
        }
    }
}

