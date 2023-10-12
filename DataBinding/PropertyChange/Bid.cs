namespace PropertyChange;

class Bid {
    public Bid(string newBidItemName, decimal newBidItemPrice) {
        _bidItemName = newBidItemName;
        _bidItemPrice = newBidItemPrice;
    }

    public string BidItemName {
        get { return _bidItemName; }
        set {
            if (!_bidItemName.Equals(value)) {
                _bidItemName = value;
            }
        }
    }

    public decimal BidItemPrice {
        get { return _bidItemPrice; }
        set {
            if (!_bidItemPrice.Equals(value)) {
                _bidItemPrice = value;

            }
        }
    }

    private string _bidItemName;
    private decimal _bidItemPrice;
}

