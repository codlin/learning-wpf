using System.Collections.ObjectModel;

namespace MultiBinding;
internal class NameList : ObservableCollection<PersonName> {
    public NameList() {
        Add(new PersonName("Willa", "Cather"));
        Add(new PersonName("Isak", "Dinesen"));
        Add(new PersonName("Victor", "Hugo"));
        Add(new PersonName("Jules", "Verne"));
    }
}

