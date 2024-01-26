using EduPlatform.Models;

namespace EduPlatform.Services {
    public class CourseService {
        private IList<Course> courses;
        private static object threadLock = new();
        private static CourseService? instance;
        public static CourseService Current {
            get {
                lock(threadLock) {               
                    if(instance == null) {
                        instance = new CourseService();
                    }
                }
                return instance;
            }
        }
        private CourseService() {
            courses = new List<Course>();
        }

        public List<Course> Search(string? query) { 
                return courses.Where(
                c => 
                    c.Name.ToUpper().Contains(query?.ToUpper() ?? string.Empty)
                    || c.Code.ToUpper().Contains(query?.ToUpper() ?? string.Empty)).ToList();
        }

        public void Add(Course newCourse) {
            courses.Add(newCourse);
        }

        public Course SelectCourse() {

            int count = 0;
            Console.WriteLine("Select a Course: ");
            foreach(Course c in courses)
            {
                Console.WriteLine(++count + ". " + c);
            }
            Console.WriteLine("Type Selection: ");

            int intTemp = Convert.ToInt32(Console.ReadLine());
            if(intTemp != 0){
                Console.WriteLine("Selected: " + courses[intTemp-1]);
            }
            else {
                Console.WriteLine("Typed Selection is Invalid!");
            }

            return courses[intTemp-1];
        }

        public void AddStudent(Student student, Course course) {
            course.Enroll(student);
        }
        public void RemoveStudent(Student student, Course course) {
            // have to get name from student argument and use that to unenroll Person model
            course.Unenroll(student);
        }
        public void Print() {
            foreach(Course course in courses){
                Console.WriteLine(course.ToString());
            }
        }
    }
}