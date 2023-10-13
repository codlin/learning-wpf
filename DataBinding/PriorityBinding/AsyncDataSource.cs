using System.Threading;

namespace PriorityBinding;

internal class AsyncDataSource {
    private string _slowerDp = "";
    private string _slowestDp = "";
    public string FastDp { get; set; } = "";

    public string SlowerDp {
        get {
            // This simulates a lengthy time before the
            // data being bound to is actualy available.
            Thread.Sleep(3000);
            return _slowerDp;
        }
        set { _slowerDp = value; }
    }

    public string SlowestDp {
        get {
            // This simulates a lengthy time before the
            // data being bound to is actualy available.
            Thread.Sleep(5000);
            return _slowestDp;
        }
        set { _slowestDp = value; }
    }
}

