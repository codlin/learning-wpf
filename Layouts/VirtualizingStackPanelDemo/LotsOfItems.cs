using System.Collections.ObjectModel;

namespace VirtualizingStackPanelDemo;
public class LotsOfItems : ObservableCollection<string> {
    public LotsOfItems() {
        for (int i = 0; i < 1000000; ++i) {
            Add("item " + i.ToString());
        }
    }
}

