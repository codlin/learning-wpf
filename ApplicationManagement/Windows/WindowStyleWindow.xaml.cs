﻿using System;
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
    /// WindowStyleWindow.xaml 的交互逻辑
    /// </summary>
    public partial class WindowStyleWindow : Window {
        public WindowStyleWindow() {
            InitializeComponent();
            Loaded += Window_Loaded;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            winStyle.Text = WindowStyle.ToString();
        }
    }
}
