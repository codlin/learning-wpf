using System.Windows;
using System.Windows.Controls;

namespace DataTemplatingIntro;
internal class TaskListDataTemplateSelector : DataTemplateSelector {
    public override DataTemplate? SelectTemplate(object item, DependencyObject container) {
        if (item != null && item is Task) {
            var win = Application.Current.MainWindow;
            var task = (Task)item;
            if (task.Priority == 1) {
                return win.FindResource("ImportantTaskTemplate") as DataTemplate;
            }

            return win.FindResource("MyTaskTemplate") as DataTemplate;
        }

        return null;
    }
}
