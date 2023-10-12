using System.Windows;

namespace Windows {
    /// <summary>
    /// GetMainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class GetMainWindow : Window {
        public GetMainWindow() {
            InitializeComponent();
        }

        private void Get_MainWindow_Title(object sender, RoutedEventArgs e) {
            MessageBox.Show($"The main window's title is : {Application.Current.MainWindow.Title}");
        }
    }
}
