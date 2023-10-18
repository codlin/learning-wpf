namespace MasterDetail;
internal class League {
    public League(string name) {
        Name = name;
        Divisions = new DivisionList();
    }

    public string Name { get; }
    public DivisionList Divisions { get; }

    public override string ToString() => Name;
}
