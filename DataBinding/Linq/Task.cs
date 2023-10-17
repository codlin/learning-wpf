using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Linq;

class Task : INotifyPropertyChanged {
    public event PropertyChangedEventHandler? PropertyChanged;

    private string _description;
    private string _name;
    private int _priority;
    private TaskType _type;

    public Task() : this("", "", 0, TaskType.Home) {
    }

    public Task(string name, string description, int priority, TaskType type) {
        _name = name;
        _description = description;
        _priority = priority;
        _type = type;
    }

    public string TaskName {
        get { return _name; }
        set {
            _name = value;
            OnPropertyChanged();
        }
    }

    public string Description {
        get { return _description; }
        set {
            _description = value;
            OnPropertyChanged();
        }
    }

    public int Priority {
        get { return _priority; }
        set {
            _priority = value;
            OnPropertyChanged();
        }
    }

    public TaskType TaskType {
        get { return _type; }
        set {
            _type = value;
            OnPropertyChanged();
        }
    }

    public override string ToString() {
        return _name;
    }

    protected void OnPropertyChanged([CallerMemberName] string name = "") {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
