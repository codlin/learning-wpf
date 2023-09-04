namespace IntroToStylingAndTemplating {
    public class Photo {
        public string Source { get; }

        public Photo(string path) {
            Source = path;
        }

        public override string ToString() {
            return Source;
        }

    }
}

