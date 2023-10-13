using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace CodeOnlyBinding;
internal class MyApp : Application {
    public Button Button;
    public Button Button2;
    public DockPanel Dp;
    public TextBlock MyText;

    public void OnClick(object obj, RoutedEventArgs args) {
        var fe = (FrameworkElement)obj;
        switch (fe.Name) {
            case "Clear":
                BindingOperations.ClearBinding(MyText, TextBlock.TextProperty);
                break;

            case "Refresh":

                BindingOperations.ClearBinding(MyText, TextBlock.TextProperty);
                //make a new source
                MyData myData = new(DateTime.Now);
                Binding myBinding = new("MyDataProperty") { Source = myData };
                MyText.SetBinding(TextBlock.TextProperty, myBinding);
                break;
        }
    }
    protected override void OnStartup(StartupEventArgs e) {
        RoutedEventHandler clickHandler = new(OnClick);

        Window win = new() {
            Width = 250,
            Height = 200
        };

        DockPanel root = new();
        win.Content = root;
        root.Width = 200;
        root.Height = 150;

        Dp = new DockPanel();
        DockPanel.SetDock(Dp, Dock.Top);
        root.Children.Add(Dp);

        Button = new() {
            Name = "Clear",
            Content = "Clear Binding",
            Width = 120,
            Height = 30
        };
        Button.Click += clickHandler;
        DockPanel.SetDock(Button, Dock.Top);
        Dp.Children.Add(Button);

        Button2 = new Button {
            Name = "Refresh",
            Content = "Refresh Binding",
            Width = 120,
            Height = 30
        };
        Button2.Click += clickHandler;
        DockPanel.SetDock(Button2, Dock.Top);
        Dp.Children.Add(Button2);

        MyText = new TextBlock {
            Text = "no binding yet...",
            Height = 35,
            HorizontalAlignment = HorizontalAlignment.Center
        };
        DockPanel.SetDock(MyText, Dock.Top);
        Dp.Children.Add(MyText);

        win.Show();
    }
}
