using System.Collections.ObjectModel;

namespace CollectionBinding;
internal class People : ObservableCollection<Person> {
    public People() {
        Add(new Person("Michael", "Alexander", "Bellevue"));
        Add(new Person("Jeff", "Hay", "Redmond"));
        Add(new Person("Christina", "Lee", "Kirkland"));
        Add(new Person("Samantha", "Smith", "Seattle"));
    }
}
