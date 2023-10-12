using System.Windows;
using System.Windows.Data;

namespace IntroToStylingAndTemplating {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private PhotoList? photos;

        public MainWindow() {
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e) {
            photos = (PhotoList?)(Resources["MyPhotos"] as ObjectDataProvider)?.Data;
            photos!.Path = "images";
        }
    }
}
