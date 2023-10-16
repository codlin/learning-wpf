using System.Windows;

namespace EditingCollections;
/// <summary>
/// ChangeItem.xaml 的交互逻辑
/// </summary>
public partial class ChangeItem : Window {
    public ChangeItem() {
        InitializeComponent();
    }

    private void Submit_Click(object sender, RoutedEventArgs e) {
        DialogResult = true;
        Close();
    }
}
