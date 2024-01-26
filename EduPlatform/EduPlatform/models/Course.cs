

using System.ComponentModel;

namespace EduPlatform.Models {
    
    public class Course {
        public Course() {
            roster = new List<Person>();
        }
        IList<Person> roster;
        protected string? _name;
        public string Name{
            get { return _name ?? "EMPTY";}
            set { _name = value; }  
        }
        protected string? _code;
        public string Code{
            get { return _code ?? "EMPTY"; }
            set { _code = value?.ToUpper();}  
        }
        protected string? _description;
        public string? Description{
            get { return _description; }
            set { _description = value; }  
        }
        public override string ToString()
        {
            return $"({Code}) {Name} - {Description}";
        }

        public void Enroll(Student student) {
            Person newPerson = new Person{Name = student.Name, Classification = student.Class};
            roster.Add(newPerson);
        }

        public void PrintCourseDetails() {
            Console.WriteLine(ToString());
            Console.WriteLine($"{Code} Students:");
            foreach(var person in roster) {
                Console.WriteLine(person.ToString());
            }
        }
    }
}