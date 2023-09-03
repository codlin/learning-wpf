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
 * MinWidth、Width 和 MaxWidth 用于管理窗口在其生存期内可以具有的宽度范围。
 * 窗口高度由 MinHeight、Height 和 MaxHeight 管理。
 * 可以在 XAML 里面设置这些属性，也可以通过编程的方式设置。
 * 若要检测其当前的宽度和高度，请分别检查 ActualWidth 和 ActualHeight。 
 * 如果希望窗口的宽度和高度适应窗口内容的大小，可以使用 SizeToContent 属性，它具有以下值：
 * - SizeToContent.Manual 不起作用（默认值）。
 * - SizeToContent.Width 适应内容宽度，与将 MinWidth 和 MaxWidth 都设置为内容的宽度效果相同。
 * - SizeToContent.Height 适应内容高度，与将 MinHeight 和 MaxHeight 都设置为内容的高度效果相同。
 * - SizeToContent.WidthAndHeight 适应内容宽度和高度，与将 MinHeight 和 MaxHeight 都设置为内容的高度，并将 MinWidth 和 MaxWidth 都设置为内容的宽度效果相同。
 * 大小调整属性的优先级顺序:
 * 为了确保保持有效的范围，Window 将使用以下优先级顺序计算大小属性的值。
 * 对于高度属性：
 * 1. FrameworkElement.MinHeight
 * 2. FrameworkElement.MaxHeight
 * 3. SizeToContent.Height or SizeToContent.WidthAndHeight
 * 4. FrameworkElement.Height
 * 对于宽度属性：
 * 1. FrameworkElement.MinWidth
 * 2. FrameworkElement.MaxWidth
 * 3. SizeToContent.Width or SizeToContent.WidthAndHeight
 * 4. FrameworkElement.Width
 * 优先级顺序还可以确定窗口在最大化时的大小，此时的窗口大小由 WindowState 属性管理。
 * 一个 WindowState，确定窗口是处于还原、最小化还是最大化状态。 默认值为 Normal（还原）。
*/

namespace Windows {
    /// <summary>
    /// SizedWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SizedWindow : Window {
        public SizedWindow() {
            InitializeComponent();
            SizeToContent = SizeToContent.WidthAndHeight;
        }

    }
}
