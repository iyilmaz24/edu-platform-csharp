
namespace EduPlatform.Models {
    
    public class Student {
        
        public Student(string name, string classI) {
            Name = name;
            Class = classI;
        }

        private string? _class;
        public string? Class {
            get { return _class; }
            set { _class = value?.ToUpper(); }
        }

        private string? _name;
        public string? Name {
            get { return _name; }
            set { _name = value; }
        }

        public override string ToString()
        {
            return $"{Name} - {Class}";
        }
    }
}