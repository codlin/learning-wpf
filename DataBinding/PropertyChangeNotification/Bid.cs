using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PropertyChangeNotification;

class Bid : INotifyPropertyChanged {
    public event PropertyChangedEventHandler? PropertyChanged;

    public Bid(string newBidItemName, decimal newBidItemPrice) {
        _bidItemName = newBidItemName;
        _bidItemPrice = newBidItemPrice;
    }

    public string BidItemName {
        get { return _bidItemName; }
        set {
            if (!_bidItemName.Equals(value)) {
                _bidItemName = value;
                OnPropertyChanged();
            }
        }
    }

    public decimal BidItemPrice {
        get { return _bidItemPrice; }
        set {
            if (!_bidItemPrice.Equals(value)) {
                _bidItemPrice = value;
                OnPropertyChanged();
            }
        }
    }

    private void OnPropertyChanged([CallerMemberName] string propName = "") {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }

    private string _bidItemName;
    private decimal _bidItemPrice;
}

