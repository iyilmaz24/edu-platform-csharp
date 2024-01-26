

namespace EduPlatform.Models {

   public class ContentItem {
        public ContentItem(string name, string description, string path) {
            Name = name;
            Description = description;
            Path = path;
        }

        private string? _name;
        public string? Name {
            get { return _name; }
            set { _name = value; }
        }

        private string? _description;
        public string? Description {
            get { return _description; }
            set { _description = value; }
        }

        private string? _path;
        public string? Path {
            get { return _path; }
            set { _path = value; }
        }
    
    }
}