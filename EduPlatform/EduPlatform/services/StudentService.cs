
using EduPlatform.Models;

namespace EduPlatform.Services
{
    public class StudentService {
        
        private static object threadLock = new();
        private static StudentService? instance;
        public IList<Student> students;

        public static StudentService Current {   
            get {
                lock(threadLock) {
                    if(instance == null) {
                    instance = new StudentService();
                    }
                }
                return instance;
            }        
        } 
        private StudentService() {
            students = new List<Student>();
        }

        public List<Student> Search(string? query) { 
                return students.Where(
                s => 
                    s.Name.ToUpper().Contains(query?.ToUpper() ?? string.Empty)).ToList();
        }
        public void SearchBackend(string? query) {
            List<Student> searchResults = Search(query??"0");
            Console.WriteLine("===== Search Results ======");
                if(searchResults.Count() == 0){
                    Console.WriteLine("Returned 0 Total Results.");
                }
                else {
                    foreach(var s in searchResults){
                        Console.WriteLine(s.ToString());
                    }
                }
            Console.WriteLine("=====//============//======");
        }
            
        public void AddStudent(Student student) {
            students.Add(student);
        }

        public Student SelectStudent() {
            
            int count = 0;
            Console.WriteLine("Select a Student: ");
            foreach(Student s in students)
            {
                Console.WriteLine(++count + ". " + s);
            }
            Console.WriteLine("Type Selection: ");

            int intTemp = Convert.ToInt32(Console.ReadLine());
            if(intTemp != 0){
                Console.WriteLine("Selected: " + students[intTemp-1]);
            }
            else {
                Console.WriteLine("Typed Selection is Invalid!");
            }

            return students[intTemp-1];
        }

        public void PrintStudents() {
            foreach(Student student in students) {
                Console.WriteLine(student.ToString());
            }
        }
    }
}
