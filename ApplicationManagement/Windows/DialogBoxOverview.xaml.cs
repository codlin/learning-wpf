using System.Windows;

/*
 * WPF 提供了自行设计对话框的方法。 对话框是窗口，但具有特定的意图和用户体验。 对话框用于：
 * - 向用户显示特定信息。
 * - 从用户处收集信息。
 * - 同时显示并收集信息。
 * - 显示操作系统提示，例如打印窗口。
 * - 选择文件或文件夹。
 * 这些类型的窗口称为对话框。对话框可以通过两种方式显示：模态和非模态。
 * 向用户显示模态对话框是一种技术，应用程序使用该技术中断其正在执行的操作，直到用
 * 户关闭对话框。 这通常以提示或警报的形式出现。 在关闭对话框之前，无法与应用程序
 * 中的其他窗口进行交互。 模式对话框关闭后，应用程序将继续运行。 
 * 最常见的对话框用于显示打开文件或保存文件提示、显示打印机对话框或向用户发送一些状态消息。
 * 
 * 非模态对话框打开时不会阻止用户激活其他窗口。 例如，如果用户想要在文档中查找特
 * 定单词的匹配项，主窗口通常会打开一个对话框，询问用户要查找什么单词。 由于应用
 * 程序不想阻止用户编辑文档，因此该对话框不必为模式对话框。 非模式对话框至少提供
 * “关闭”按钮来关闭对话框。 可能还会提供其他按钮来运行特定功能，例如提供“查找下一
 * 个”按钮以在单词搜索中查找下一个单词。
*/
namespace Windows {
    /// <summary>
    /// DialogBoxOverview.xaml 的交互逻辑
    /// </summary>
    public partial class DialogBoxOverview : Window {
        public DialogBoxOverview() {
            InitializeComponent();
        }

        /* 消息框是可以用来显示文本信息并允许用户使用按钮做出决定的对话框。*/
        private void Open_Msg_Dialog(object sender, RoutedEventArgs e) {
            MessageBox.Show("Do you want to save changes?", "Word Processor", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning, MessageBoxResult.Yes);
        }

        /*
         * Windows 实现了所有应用程序通用的不同类型的可重用对话框，其中包括用于选择文件和打印的对话框。
         * 由于这些对话框是由操作系统提供的，因此它们在操作系统上运行的所有应用程序之间共享。 
         * 这些对话框提供一致的用户体验，被称为通用对话框。 当用户在一个应用程序中使用通用对话框时，他们不需要学习如何在其他应用程序中使用该对话框。
         * WPF 封装了“打开文件”、“保存文件”和“打印”通用对话框，并将它们公开为托管类，供你在独立应用程序中使用。
         * 
         * 常见的打开文件对话框作为 OpenFileDialog 类实现，并位于 Microsoft.Win32 命名空间中。
        */
        private void Open_File_Dialog(object sender, RoutedEventArgs e) {
            var dialog = new Microsoft.Win32.OpenFileDialog {
                FileName = "Document",
                DefaultExt = ".txt",
                Filter = "Text documents (.txt)|*.txt"
            };

            bool? result = dialog.ShowDialog();
            if (result == true) {
                //
            }
        }

        /* 常见的保存文件对话框作为 SaveFileDialog 类实现，并位于 Microsoft.Win32 命名空间中。 */
        private void Save_File_Dialog(object sender, RoutedEventArgs e) {
            var dialog = new Microsoft.Win32.SaveFileDialog {
                FileName = "Document",
                DefaultExt = ".txt",
                Filter = "Text documents (.txt)|*.txt"
            };

            bool? result = dialog.ShowDialog();
            if (result == true) {
                //
            }
        }

        /* 常见的打印对话框作为 PrintDialog 类实现，并位于 System.Windows.Controls 命名空间中。*/
        private void Print_Dialog(object sender, RoutedEventArgs e) {
            var dialog = new System.Windows.Controls.PrintDialog();
            dialog.PageRangeSelection = System.Windows.Controls.PageRangeSelection.AllPages;
            dialog.UserPageRangeEnabled = true;

            bool? result = dialog.ShowDialog();
            if (result == true) {
                //
            }
        }
    }
}
