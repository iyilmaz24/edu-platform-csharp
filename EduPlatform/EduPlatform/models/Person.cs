

namespace EduPlatform.Models {

    public class Person {

        public Person() {
            Grades = new List<Grade>();
        }

        // use initializer list instead of parameterized constructor
            // Person(string name, string classification) {
            //     Name = name;
            //     Classification = classification;
            //     Grades = new List<Grade>();
            // }

        private string? _name;
        public string? Name {
            get { return _name; }
            set { _name = value; }
        }

        private string? _classification;
        public string? Classification {
            get { return _classification; }
            set { _classification = value; }
        }

        public override string ToString()
        {
            return $"{Name} - {Classification}";
        }
        private IList<Grade>? Grades;

    }

}