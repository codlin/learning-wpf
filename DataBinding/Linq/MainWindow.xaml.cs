using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Linq {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private readonly Tasks tasks = new();

        public MainWindow() {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            _ = int.TryParse(((sender as ListBox)?.SelectedItem as ListBoxItem)?.Content.ToString(), out int pri);
            DataContext = from task in tasks
                          where task.Priority == pri
                          select task;
        }
    }
}
