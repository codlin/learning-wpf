using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace SortFilter {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public ListCollectionView MyCollectionView;
        // Object o keeps the currency for the table
        public Order O;

        public MainWindow() {
            InitializeComponent();
        }

        private void StartHere(object sender, DependencyPropertyChangedEventArgs e) {
            MyCollectionView = (ListCollectionView)CollectionViewSource.GetDefaultView(rootElement.DataContext);
        }

        private void OnClick(object sender, RoutedEventArgs e) {
            var button = sender as Button;
            MyCollectionView.SortDescriptions.Clear();
            switch (button?.Name) {
                case "orderButton":
                    MyCollectionView.SortDescriptions.Add(new SortDescription("OrderItem", ListSortDirection.Ascending));
                    break;
                case "customerButton":
                    MyCollectionView.SortDescriptions.Add(new SortDescription("Customer",
                        ListSortDirection.Ascending));
                    break;
                case "nameButton":
                    MyCollectionView.SortDescriptions.Add(new SortDescription("Name",
                        ListSortDirection.Ascending));
                    break;
                case "idButton":
                    MyCollectionView.SortDescriptions.Add(new SortDescription("Id",
                        ListSortDirection.Ascending));
                    break;
                case "filledButton":
                    MyCollectionView.SortDescriptions.Add(new SortDescription("Filled",
                        ListSortDirection.Ascending));
                    break;
            }
        }

        private void OnBrowse(object sender, RoutedEventArgs e) {
            var button = sender as Button;
            switch (button?.Name) {
                case "Previous":
                    if (MyCollectionView.MoveCurrentToPrevious()) {
                        feedbackText.Text = "";
                        O = (Order)MyCollectionView.CurrentItem;
                    } else {
                        feedbackText.Text = "At first record";
                        MyCollectionView.MoveCurrentToFirst();
                    }
                    break;
                case "Next":
                    if (MyCollectionView.MoveCurrentToNext()) {
                        feedbackText.Text = "";
                        O = (Order)MyCollectionView.CurrentItem;
                    } else {
                        feedbackText.Text = "At last record";
                        MyCollectionView.MoveCurrentToLast();
                    }
                    break;
            }
        }

        private bool Contains(object de) {
            var order = de as Order;
            //Return members whose Orders have not been filled
            return (order?.Filled == "No");
        }

        private void OnFilter(object sender, RoutedEventArgs e) {
            var button = sender as Button;
            switch (button?.Name) {
                case "Filter":
                    MyCollectionView.Filter = Contains;
                    break;
                case "Unfilter":
                    MyCollectionView.Filter = null;
                    break;
            }
        }
    }
}
