using System.Collections.ObjectModel;
using System.Timers;

namespace PropertyChangeNotification;

class BidCollection : ObservableCollection<Bid> {
    private readonly Bid _item1 = new Bid("Perseus Vase", (decimal)24.95);
    private readonly Bid _item2 = new Bid("Hercules Statue", (decimal)16.05);
    private readonly Bid _item3 = new Bid("Odysseus Painting", (decimal)100.0);

    public BidCollection() {
        Add(_item1);
        Add(_item2);
        Add(_item3);

        CreateTimer();

    }
    private void CreateTimer() {
        Timer timer = new() {
            Enabled = true,
            Interval = 2000
        };

        timer.Elapsed += Timer_Elapsed;
    }

    private void Timer_Elapsed(object? sender, ElapsedEventArgs e) {
        _item1.BidItemPrice += (decimal)1.25;
        _item2.BidItemPrice += (decimal)2.45;
        _item3.BidItemPrice += (decimal)10.55;
    }
}

