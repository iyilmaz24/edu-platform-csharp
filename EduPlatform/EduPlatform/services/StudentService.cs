
using EduPlatform.Models;

namespace EduPlatform.Services
{
    public class StudentService {
        
        private static object threadLock = new();
        private static StudentService? instance;
        public IList<Student> Students;

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
            Students = new List<Student>();
        }
            
        public void AddStudent(Student student) {
            Students.Add(student);
        }

        public void PrintStudents() {
            foreach(Student student in Students) {
                Console.WriteLine(student.ToString());
            }
        }
    }
}
