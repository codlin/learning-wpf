using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DirectionalBinding;
internal class NetIncome : INotifyPropertyChanged {
    private int _food = 0;
    private int _misc = 0;
    private int _rent = 2000;
    private int _savings = 0;
    private int _totalIncome = 5000;

    public NetIncome() {
        _savings = _totalIncome - (_rent + _food + _misc);
    }

    public int TotalIncome {
        get { return _totalIncome; }
        set {
            if (TotalIncome != value) {
                _totalIncome = value;
                OnPropertyChanged();
            }
        }
    }

    public int Rent {
        get { return _rent; }
        set {
            if (Rent != value) {
                _rent = value;
                OnPropertyChanged();
                UpdateSavings();
            }
        }
    }

    public int Food {
        get { return _food; }
        set {
            if (Food != value) {
                _food = value;
                OnPropertyChanged();
                UpdateSavings();
            }
        }
    }

    public int Misc {
        get { return _misc; }
        set {
            if (Misc != value) {
                _misc = value;
                OnPropertyChanged();
                UpdateSavings();
            }
        }
    }

    public int Savings {
        get { return _savings; }
        set {
            if (Savings != value) {
                _savings = value;
                OnPropertyChanged();
                UpdateSavings();
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void UpdateSavings() {
        Savings = TotalIncome - (Rent + Misc + Food);
        if (Savings < 0) {
        } else if (Savings >= 0) {
        }
    }

    private void OnPropertyChanged([CallerMemberName] string info = "") {
        var handler = PropertyChanged;
        handler?.Invoke(this, new PropertyChangedEventArgs(info));
    }
}

