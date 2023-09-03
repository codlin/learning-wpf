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
using System.Windows.Shapes;

/*
 * 窗口的生存期在用户关闭它时终止。 窗口关闭后，就不能再重新打开它。 可以使用非工作区中的元素关闭窗口，这些元素包括：
 * - “系统”菜单的“关闭”项。
 * - 按 ALT+F4。
 * - 按“关闭”按钮。
 * - 在模式窗口上，当按钮的 IsCancel 属性设置为 true 时，按 ESC。
 * 可以向工作区提供关闭窗口的更多机制，较为常见的机制包括：
 * - “文件”菜单中的“退出”项，通常用于主应用程序窗口。
 * - “文件”菜单中的“关闭”项，通常位于辅助应用程序窗口中。
 * - “取消”按钮，通常位于模式对话框中。
 * - “关闭”按钮，通常位于非模式对话框中。
 * 若要为响应其中一种自定义机制而关闭窗口，需要调用 Close 方法。
 * 虽然窗口可通过非工作区和工作区中提供的机制显式关闭，但它也可能因为应用程序或 Windows 的其他部分中的行为而隐式关闭，行为包括：
 * - 用户注销或关闭 Windows。
 * - 窗口的 Owner 关闭。
 * - 主应用程序窗口关闭且 ShutdownMode 为 OnMainWindowClose。
 * - 调用 Shutdown。
 * 可将应用程序配置为在出现以下情况时自动关闭：主应用程序窗口关闭（请参阅 MainWindow）或最后一个窗口关闭。有关详细信息，请参阅 ShutdownMode。
 */
namespace Windows {
    /// <summary>
    /// CloseWindow.xaml 的交互逻辑
    /// </summary>
    public partial class CloseWindow : Window {
        private bool _isDataDirty;

        public CloseWindow() {
            InitializeComponent();
            Closing += Window_Closing;
        }

        /*
         * 窗口关闭时，会引发两个事件：Closing 和 Closed。
         * Closing 在窗口关闭前引发，并提供一种可以阻止窗口关闭的机制。 阻止窗口关闭的一个常见原因是窗口内容包含修改的数据。 
         * 在这种情况下，处理 Closing 事件可以确定数据是否为已更新，如果已更新，询问用户是在不保存数据的情况下继续关闭窗口，还是取消关闭窗口。 
         * 以下示例演示了处理 Closing 的关键方面。
         * 向 Closing 事件处理程序传递 CancelEventArgs，它会实现 Cancel 属性，将该属性设置为 true 以防止窗口关闭。 
         * 如果未处理 Closing，或者已处理但未取消，窗口将关闭。 在窗口真正关闭前，将引发 Closed。 此时，无法阻止窗口关闭。
        */
        private void Window_Closing(object? sender, System.ComponentModel.CancelEventArgs e) {
            if (_isDataDirty) {
                var result = MessageBox.Show("Document has changed. Close without saving?", "Question", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.No) {
                    e.Cancel = true;
                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e) {
            _isDataDirty = true;
        }
    }
}
