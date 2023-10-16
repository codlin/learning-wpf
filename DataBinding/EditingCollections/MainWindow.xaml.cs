using System.ComponentModel;
using System.Windows;

namespace EditingCollections;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();
    }

    private void Add_Click(object sender, RoutedEventArgs e) {
        var editableCollectionView = itemsControl.Items as IEditableCollectionView;
        if (!editableCollectionView.CanAddNew) {
            MessageBox.Show("You cannot add items to the list.");
            return;
        }

        var win = new ChangeItem { DataContext = editableCollectionView.AddNew() };
        if (win.ShowDialog().GetValueOrDefault()) {
            editableCollectionView.CommitNew();
        } else {
            editableCollectionView.CancelNew();
        }
    }

    private void Edit_Click(object sender, RoutedEventArgs e) {
        if (itemsControl.SelectedItem == null) {
            MessageBox.Show("No item is selected");
            return;
        }

        var editableCollectionView = itemsControl.Items as IEditableCollectionView;
        editableCollectionView.EditItem(itemsControl.SelectedItem);

        var win = new ChangeItem();
        win.DataContext = itemsControl.SelectedItem;
        if (win.ShowDialog().GetValueOrDefault()) {
            editableCollectionView.CommitEdit();
        } else {
            editableCollectionView.CancelEdit();
        }

    }

    private void Remove_Click(object sender, RoutedEventArgs e) {
        var item = itemsControl.SelectedItem as PurchaseItem;
        if (item == null) {
            MessageBox.Show("No item is selected");
            return;
        }

        var editableCollectionView = itemsControl.Items as IEditableCollectionView;
        if (!editableCollectionView.CanRemove) {
            MessageBox.Show("You cannot remove items from the list.");
            return;
        }

        if (MessageBox.Show("Are you sure you want to remove " + item.Description,
               "Remove Item", MessageBoxButton.YesNo) == MessageBoxResult.Yes) {
            editableCollectionView.Remove(itemsControl.SelectedItem);
        }
    }
}
