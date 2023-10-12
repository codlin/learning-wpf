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
    /// ActivatedWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ActivatedWindow : Window {
        public ActivatedWindow() {
            InitializeComponent();
            Deactivated += ActivatedWindow_Deactivated;
        }

        private void ActivatedWindow_Deactivated(object? sender, EventArgs e) {
            //MessageBox.Show("Window was deactivated");
            message.Text = "window was deactivated";
        }

        void Window_Activated(object sender, EventArgs e) {
            message.Text = "window was activated";
        }
    }
}
