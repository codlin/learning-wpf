using System.Windows;

namespace Windows {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        public App() {
            /*
             * 通过设置 ShutdownMode 来改变调用 Shutdown() 方法的条件。
             * 仅当调用 Application 的 方法时 Shutdown ，应用程序才会停止运行。 关闭可以隐式或显式发生，由 属性的值 ShutdownMode 指定。
             * - 如果设置为 ShutdownModeOnMainWindowClose，这会导致 WPF 在关闭时 MainWindow 隐式调用 Shutdown，即使其他窗口当前处于打开状态。
             * - 如果设置为 ShutdownModeOnLastWindowClose，WPF 会在应用程序的最后一个窗口关闭时隐式调用 Shutdown，即使当前任何实例化的窗口都设置为主窗口， (可以看到MainWindow) 。
             * - 某些应用程序的生存期可能不依赖于关闭主窗口或最后一个窗口的时间，或者可能根本不依赖于窗口。 
             *   对于这些方案， ShutdownMode 需要将 属性设置为 OnExplicitShutdown，这需要显式 Shutdown 方法调用来停止应用程序。 否则，应用程序将继续在后台运行。
             * ShutdownMode 可以从 XAML 以声明方式配置，也可以通过代码以编程方式进行配置。
             * 此属性仅在创建 对象的线程中 Application 可用。
             */
            ShutdownMode = ShutdownMode.OnMainWindowClose;
            //ShutdownMode = ShutdownMode.OnLastWindowClose;
            //ShutdownMode = ShutdownMode.OnExplicitShutdown;

            // 通过代码设置主窗口
            Application.Current.MainWindow = new MainWindow();
            Application.Current.MainWindow.Show();
        }
    }
}
