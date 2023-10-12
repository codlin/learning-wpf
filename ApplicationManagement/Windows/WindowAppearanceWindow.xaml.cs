using System.Windows;

/*
 * 重设大小模式
 * 根据 WindowStyle 属性，你可以控制用户是否可以重设窗口的大小，以及如何重设。 窗口样式影响以下各项：
 * - 允许或禁止使用鼠标拖动窗口边框来调整大小。
 * - 非工作区是否显示“最小化”、“最大化”和“关闭”按钮。
 * - 是否启用了“最小化”、“最大化”和“关闭”按钮。
 * 可以通过设置窗口的 ResizeMode 属性来配置重设窗口大小的方式，该属性可以是下列 ResizeMode 枚举值之一：
 * - NoResize
 * - CanMinimize
 * - CanResize（默认值）
 * - CanResizeWithGrip 右下角带控制抓手
 * 与 WindowStyle 一样，窗口的重设大小模式在生存期中不太可能更改，这意味着它最有可能在 XAML 标记中进行设置。
 * 请注意，可以通过检查 WindowState 属性来检测是否已最大化、最小化或还原窗口。
 */
namespace Windows {
    /// <summary>
    /// WindowAppearanceWindow.xaml 的交互逻辑
    /// </summary>
    public partial class WindowAppearanceWindow : Window {
        public WindowAppearanceWindow() {
            InitializeComponent();
        }

        private void Window_NoResize(object sender, RoutedEventArgs e) {
            WindowResizeMode window = new() {
                ResizeMode = ResizeMode.NoResize
            };
            window.Show();
        }

        private void Window_CanMinimize(object sender, RoutedEventArgs e) {
            WindowResizeMode window = new() {
                ResizeMode = ResizeMode.CanMinimize
            };
            window.Show();
        }

        private void Window_Resize(object sender, RoutedEventArgs e) {
            WindowResizeMode window = new() {
                ResizeMode = ResizeMode.CanResize,
                WindowState = WindowState.Maximized,
            };
            window.Show();
        }

        private void Window_CanResizeWithGrip(object sender, RoutedEventArgs e) {
            WindowResizeMode window = new() {
                ResizeMode = ResizeMode.CanResizeWithGrip
            };
            window.Show();
        }

        private void Window_StyleNone(object sender, RoutedEventArgs e) {
            WindowStyleWindow window = new() {
                WindowStyle = WindowStyle.None
            };
            window.Show();
        }

        private void Window_SingleBorder(object sender, RoutedEventArgs e) {
            WindowStyleWindow window = new() {
                WindowStyle = WindowStyle.SingleBorderWindow
            };
            window.Show();
        }

        private void Window_ThreeDBorder(object sender, RoutedEventArgs e) {
            WindowStyleWindow window = new() {
                WindowStyle = WindowStyle.ThreeDBorderWindow
            };
            window.Show();
        }

        private void Window_Tool(object sender, RoutedEventArgs e) {
            WindowStyleWindow window = new() {
                WindowStyle = WindowStyle.ToolWindow
            };
            window.Show();
        }

        private void NonRectangularWindow(object sender, RoutedEventArgs e) {
            NonRectangularWindow window = new();
            window.Show();
        }
    }
}
