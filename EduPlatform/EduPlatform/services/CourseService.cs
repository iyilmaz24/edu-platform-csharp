using EduPlatform.Models;

namespace EduPlatform.Services {
    public class CourseService {
        private IList<Course> courses;
        private string? query;
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

        // public IEnumerable<Course> Courses {
        //     get {
        //         Console.WriteLine("Search performed");
        //         return courses.Where(
        //         c => 
        //             c.Name.ToUpper().Contains(query ?? string.Empty)
        //             || c.Code.ToUpper().Contains(query ?? string.Empty)).ToList();
        //     }
        // }
        // public void Search(string? query) {
        //     this.query = query ?? "None";

        //     if(query == "None") {
        //         Console.WriteLine("Invalid Search, Try Again.");
        //         return;
        //     }

        //     IEnumerable<Course> result =  Courses;
        //     if(result is not IEnumerable<Course>){
        //         Console.WriteLine("if queryResult is not IEnumerable<Course>");
        //     }
        //     else {
        //         Console.WriteLine(result.Count());
        //     }
        // }

        public void Add(Course newCourse) {
            courses.Add(newCourse);
        }

        public void Print() {
            foreach(Course course in courses){
                Console.WriteLine(course.ToString());
            }
        }
    }
}