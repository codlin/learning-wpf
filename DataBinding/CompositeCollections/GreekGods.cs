﻿using System.Collections.ObjectModel;

namespace CompositeCollections;
internal class GreekGods : ObservableCollection<GreekGod> {
    public GreekGods() {
        Add(new GreekGod("Aphrodite"));
        Add(new GreekGod("Apollo"));
        Add(new GreekGod("Ares"));
        Add(new GreekGod("Artemis"));
        Add(new GreekGod("Athena"));
        Add(new GreekGod("Demeter"));
        Add(new GreekGod("Dionysus"));
        Add(new GreekGod("Hephaestus"));
        Add(new GreekGod("Hera"));
        Add(new GreekGod("Hermes"));
        Add(new GreekGod("Poseidon"));
        Add(new GreekGod("Zeus"));
    }
}
