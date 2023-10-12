using System.Windows;

namespace Windows {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            ChilldWindow1 window = new ChilldWindow1();
            /* 如果使用了 Owner 属性，那么当前窗口和被打开的窗口将建立所有权关系
             * 建立所有权后：
             * - 被拥有的窗口可以通过检查其 Owner 属性的值来引用它的所有窗口。
             * - 所有者窗口可以通过检查其 OwnedWindows 属性的值来发现它所拥有的所有窗口
            */
            //window.Owner = this;
            window.Show();
        }

        private void Open_Activate_Window(object sender, RoutedEventArgs e) {
            ActivatedWindow window = new ActivatedWindow();
            window.Show();
        }

        private void Open_notActivate_Window(object sender, RoutedEventArgs e) {
            ActivatedWindow window = new ActivatedWindow();
            /*
             * 如果应用程序的窗口在显示时不应激活，可以在首次调用 Show 方法之前，先将其
             * ShowActivated 属性设置为 false。 结果是：
             * - 此窗口未激活。
             * - 未引发窗口的 Activated 事件。
             * - 当前激活的窗口保持激活状态。
             * 但是，只要用户通过单击工作区或非工作区激活了窗口，窗口就会变为激活状态。 在这种情况下：
             * - 已激活窗口。
             * - 已引发窗口的 Activated 事件。
             * - 停用之前激活的窗口。
             * - 然后按照预期，响应用户操作引发窗口的 Deactivated 和 Activated 事件。
            */
            window.ShowActivated = false;
            window.Show();
        }

        private void Open_Window_With_Exit_Menu(object sender, RoutedEventArgs e) {
            CloseWindow window = new CloseWindow();
            window.Show();
        }

        private void StartupLocation_CenterOwner(object sender, RoutedEventArgs e) {
            WindowLocation window = new WindowLocation();
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.Show();
        }

        private void StartupLocation_CenterScreen(object sender, RoutedEventArgs e) {
            WindowLocation window = new WindowLocation();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Show();
        }

        private void StartupLocation_Manual(object sender, RoutedEventArgs e) {
            WindowLocation window = new WindowLocation();
            window.WindowStartupLocation = WindowStartupLocation.Manual;
            // 如果将启动位置指定为 Manual，并且未设置 Left 和 Top 属性，Window将要求操作系统指定其显示位置。
            window.Top = 100;
            window.Left = 100;
            window.Show();
        }

        private void Set_Windown_Z(object sender, RoutedEventArgs e) {
            ZWindow window = new ZWindow();
            window.Topmost = true;
            window.Show();
        }

        private void Open_Sized_Windown(object sender, RoutedEventArgs e) {
            SizedWindow window = new SizedWindow();
            window.Show();
        }

        private void ShowInTaskBar(object sender, RoutedEventArgs e) {
            WindowStateWindow window = new WindowStateWindow();
            window.ShowInTaskbar = true;
            window.Show();
        }

        private void NotShowInTaskBar(object sender, RoutedEventArgs e) {
            WindowStateWindow window = new WindowStateWindow();
            window.ShowInTaskbar = false;
            window.Show();
        }

        private void WindowApperance(object sender, RoutedEventArgs e) {
            WindowAppearanceWindow window = new();
            window.Show();
        }

        private void Dialog_View(object sender, RoutedEventArgs e) {
            DialogBoxOverview window = new DialogBoxOverview();
            window.Show();
        }

        private void GetMainWindow(object sender, RoutedEventArgs e) {
            GetMainWindow window = new GetMainWindow();
            window.Show();
        }
    }
}
