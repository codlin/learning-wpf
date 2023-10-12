using System.ComponentModel;

namespace SimpleBinding;

internal class Person : INotifyPropertyChanged {
    public event PropertyChangedEventHandler? PropertyChanged;

    // A public paramterless constructor must be defined, otherwise it cannot be used as an object element 
    public Person() { }

    public Person(string name) { _name = name; }

    public string Name {
        get { return _name; }
        set {
            if (!_name.Equals(value)) {
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            }
        }
    }

    private string _name = string.Empty;
}

