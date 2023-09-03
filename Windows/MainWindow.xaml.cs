using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
    }
}
