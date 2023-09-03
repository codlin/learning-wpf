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

namespace Windows {
    /// <summary>
    /// ChilldWindow1.xaml 的交互逻辑
    /// </summary>
    public partial class ChilldWindow1 : Window {
        public ChilldWindow1() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            ChildWindow2 window2 = new ChildWindow2();
            // 启用 Owner 属性，当前窗口关闭时，其拥有的窗口都将关闭，否则只关闭当前窗口。
            window2.Owner = this;
            window2.Show();
        }
    }
}
