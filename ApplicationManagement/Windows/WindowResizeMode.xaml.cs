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
    /// WindowResizeMode.xaml 的交互逻辑
    /// </summary>
    public partial class WindowResizeMode : Window {
        public WindowResizeMode() {
            InitializeComponent();
            
            SizeChanged += WindowResizeMode_SizeChanged;
        }

        private void WindowResizeMode_SizeChanged(object sender, SizeChangedEventArgs e) {
            winState.Text = WindowState.ToString();
        }
    }
}
