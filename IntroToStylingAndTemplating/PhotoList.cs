using System.Collections.ObjectModel;
using System.IO;

namespace IntroToStylingAndTemplating {
    public class PhotoList : ObservableCollection<Photo> {
        private DirectoryInfo _photoDirectory;

        public PhotoList() { }

        public PhotoList(string path) : this(new DirectoryInfo(path)) { }

        public PhotoList(DirectoryInfo photoDirectory) {
            _photoDirectory = photoDirectory;
            Update();
        }

        public string Path {
            get { return _photoDirectory.FullName; }
            set {
                _photoDirectory = new DirectoryInfo(value);
                Update();
            }
        }

        public DirectoryInfo Directory {
            get { return _photoDirectory; }
            set {
                _photoDirectory = value;
                Update();
            }
        }

        private void Update() {
            foreach (var photo in _photoDirectory.GetFiles("*.jpg")) {
                Add(new Photo(photo.FullName));
            }
        }
    }
}
