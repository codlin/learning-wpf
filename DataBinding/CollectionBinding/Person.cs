using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CollectionBinding;
internal class Person : INotifyPropertyChanged {
    private string _firstname = "";
    private string _hometown = "";
    private string _lastname = "";

    public Person() {
    }

    public Person(string first, string last, string town) {
        _firstname = first;
        _lastname = last;
        _hometown = town;
    }

    public string FirstName {
        get { return _firstname; }
        set {
            _firstname = value;
            OnPropertyChanged();
        }
    }

    public string LastName {
        get { return _lastname; }
        set {
            _lastname = value;
            OnPropertyChanged();
        }
    }

    public string HomeTown {
        get { return _hometown; }
        set {
            _hometown = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public override string ToString() => _firstname;

    protected void OnPropertyChanged([CallerMemberName] string info = "") {
        var handler = PropertyChanged;
        handler?.Invoke(this, new PropertyChangedEventArgs(info));
    }
}

