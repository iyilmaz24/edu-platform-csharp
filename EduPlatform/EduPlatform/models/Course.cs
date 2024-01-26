

using System.ComponentModel;

namespace EduPlatform.Models {
    
    public class Course {
        public Course() {
            roster = new List<Person>();
            assignments = new List<Assignment>();
            modules = new List<Module>();
        }
        IList<Person> roster;
        IList<Assignment> assignments;
        IList<Module> modules;
        protected string? _name;
        public string Name{
            get { return _name ?? "EMPTY";}
            set { _name = value.ToUpper(); }  
        }
        protected string? _code;
        public string Code{
            get { return _code ?? "EMPTY"; }
            set { _code = value.ToUpper();}  
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

        public string? GetStudentName(int index) {
            return roster[index].Name;
        }

        public void Unenroll(int index) {
            roster.RemoveAt(index-1);
        }

        public void AddAssignment(Assignment newAssignment) {
            assignments.Add(newAssignment);
        }

        public void printAssignments() {
            Console.WriteLine(Code + "'s Assignment List:");
            if(assignments.Count > 0) {
                foreach(Assignment a in assignments) {
                    Console.WriteLine(a.ToString());
                }
            }
            else {
                Console.WriteLine("No Assignments Added Yet.");
            }
        }

        public void PrintCourseDetails() {
            Console.WriteLine(ToString());
            Console.WriteLine($"{Code} Students:");
            int count = 0;
            foreach(var person in roster) {
                Console.WriteLine(++count + ". " + person.ToString());
            }
        }
    }
}