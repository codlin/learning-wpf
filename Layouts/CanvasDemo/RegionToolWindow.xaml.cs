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

using CanvasDemo.RegionTools.ViewModels;

namespace CanvasDemo
{
    /// <summary>
    /// RegionToolWindow.xaml 的交互逻辑
    /// </summary>
    public partial class RegionToolWindow : Window
    {
        public RegionToolWindow()
        {
            InitializeComponent();
        }

        private void RegionRectBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is RegionToolWindowViewModel vm)
            {
                vm.IsRegionRectBtnChecked = !vm.IsRegionRectBtnChecked;
            }
        }
    }
}
