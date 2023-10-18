using System.ComponentModel;

namespace UpdateSource;
internal class UserProfile : INotifyPropertyChanged {
    private string _bidPrice = "";
    private string _itemName = "";

    public string ItemName {
        get { return _itemName; }
        set {
            _itemName = value;
            OnPropertyChanged("ItemName");
        }
    }

    public string BidPrice {
        get { return _bidPrice; }
        set {
            _bidPrice = value;
            OnPropertyChanged("BidPrice");
        }
    }

    //Declare event
    public event PropertyChangedEventHandler? PropertyChanged;
    //OnPropertyChanged event handler to update property value in binding
    private void OnPropertyChanged(string info) {
        var handler = PropertyChanged;
        handler?.Invoke(this, new PropertyChangedEventArgs(info));
    }
}
