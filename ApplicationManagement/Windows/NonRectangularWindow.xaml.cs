using System.Windows;

/*
 * 可以通过将 WindowStyle 属性设置为 None，并使用 Window 为透明度提供的特殊支持，来创建这种非常规矩形的窗口。
 */
namespace Windows {
    /// <summary>
    /// NonRectangularWindow.xaml 的交互逻辑
    /// </summary>
    public partial class NonRectangularWindow : Window {
        public NonRectangularWindow() {
            InitializeComponent();
        }

        private void Close_Window(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}
