using System.Windows;
using System.Windows.Controls;

namespace ValidateItemSample {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void StackPanel1_Loaded(object sender, RoutedEventArgs e) {
            // 将 DataContext 设置为 PurchaseItem 对象。 BindingGroup 和 Binding 对象使用它作为源。
            stackPanel1.DataContext = new PurchaseItem();

            // 开始编辑事务，使对象能够接受或回滚更改。
            stackPanel1.BindingGroup.BeginEdit();
        }

        // 当 BindingGroup 或 Binding 中的 ValidationRule 失败时，会发生此事件。
        private void ItemError(object sender, ValidationErrorEventArgs e) {
            if (e.Action == ValidationErrorEventAction.Added) {
                MessageBox.Show(e.Error.ErrorContent.ToString());
            }
        }

        private void Submit_Click(object sender, RoutedEventArgs e) {
            if (stackPanel1.BindingGroup.CommitEdit()) {
                MessageBox.Show("Item submitted");
                stackPanel1.BindingGroup.BeginEdit();
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) {
            stackPanel1.BindingGroup.CancelEdit();
            stackPanel1.BindingGroup.BeginEdit();
        }
    }
}
