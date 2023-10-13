using System;

namespace CodeOnlyBinding;
internal sealed class MainEntry {
    [STAThread]
    public static void Main() {
        MyApp app = new();
        app.Run();
    }
}
