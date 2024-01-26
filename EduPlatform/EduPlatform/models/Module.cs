

namespace EduPlatform.Models{

    public class Module {
        public Module() {
            content = new List<ContentItem>();
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

        public override string ToString()
        {
            return $"{Name} - {Description}";
        }
        private IList<ContentItem>? content;

    }

}