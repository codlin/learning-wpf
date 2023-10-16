namespace CollectionViewSource;
internal class Place {
    public Place() {
        CityName = "";
        State = "";
    }

    public Place(string name, string state) {
        CityName = name;
        State = state;
    }

    public string CityName { get; set; }
    public string State { get; set; }
}
