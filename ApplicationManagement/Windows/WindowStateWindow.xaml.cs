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
 * 可调整大小的窗口在生存期中拥有三种状态：正常、最小化和最大化。
 * 正常是窗口的默认状态。 这种状态下的窗口允许用户使用重设大小手柄或边框移动窗口和重设其大小（前提是大小可以重设）。
 * 如果 ShowInTaskbar 设置为 true，则最小化状态下的窗口将折叠到任务栏按钮；否则，它将尽可能折叠到最小大小，并将自己移动到桌面的左下角。 
 * 虽然不在任务栏显示的最小化窗口可以在桌面上四处拖动，但这两种类型的最小化窗口都不可以使用边框或重设大小手柄重设窗口大小。
 * 
 * 具有最大化状态的窗口会扩展到它能具有的最大大小，这不能超过 MaxWidth、MaxHeight 和 SizeToContent 属性指定大小。与最小化窗口一样，最大化窗口无法使用重设大小手柄或通过拖动边框来重设大小。
 * 即使窗口当前已最大化或最小化，窗口的 Top、Left、Width 和 Height 属性的值也始终表示正常状态的值。
 * 可以通过设置 WindowState 属性来配置窗口的状态，该属性可以具有以下 WindowState 枚举值之一：
 * - Normal（默认值）
 * - Maximized
 * - Minimized
 */
namespace Windows {
    /// <summary>
    /// WindowStateWindow.xaml 的交互逻辑
    /// </summary>
    public partial class WindowStateWindow : Window {
        public WindowStateWindow() {
            InitializeComponent();
            WindowState = WindowState.Maximized;
        }
    }
}
