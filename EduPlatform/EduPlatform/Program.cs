
using EduPlatform.Models;
using EduPlatform.Services;

namespace EduPlatform {

    internal class Program 
    {
        static void Main(string [] args) {

            Console.WriteLine("Welcome to C# Edu Platform!");
            
            string? exit = "N";
            while(exit == "N" || exit == "n") {
                PrintMenu();
                Console.WriteLine("Make your selection:");
                int userChoice = Convert.ToInt32(Console.ReadLine());
                MenuController(userChoice);

                Console.WriteLine("Exit Program Y or N");
                exit = Console.ReadLine()??"Y";
            }
    
            Console.WriteLine("Program Exited Successfully.");
        }

        static void AddCourse() {
            Console.WriteLine("=== Creating New Course ===");
            Console.WriteLine("Course Name:");
            var name = Console.ReadLine();
            Console.WriteLine("Course Code:");
            var code = Console.ReadLine();
            Console.WriteLine("Course Description:");
            var description = Console.ReadLine();
            Console.WriteLine("===//==================//===");
            Course newCourse;
            newCourse = new Course{Name = name??"EmptyName", Code = code??"EmptyCode", Description = description??"EmptyDescription"};
            CourseService.Current.Add(newCourse);
        }

        static void PrintCourses() {
            Console.WriteLine("===== List of Courses ======");
                CourseService.Current.Print();
            Console.WriteLine("=====//=============//======");
        }   

        static void SearchCourses() {
            Console.WriteLine("===//==================================//===");
            Console.WriteLine("Provide exact course name or code to search:");
            string? queryInput = Console.ReadLine();
            CourseService.Current.SearchBackend(queryInput);
        }   

        static void SearchStudents() {
            Console.WriteLine("===//==================================//===");
            Console.WriteLine("Provide exact student name to search:");
            string? queryInput = Console.ReadLine();
            StudentService.Current.SearchBackend(queryInput);
        }

        static void CreateStudent() {
            Console.WriteLine("=== Creating New Student ===");
            Console.WriteLine("Student Name:");
            string? name = Console.ReadLine();
            Console.WriteLine("Student Class:");
            string? classI = Console.ReadLine();
            Student student = new Student(name??"Name", classI??"Class");
            StudentService.Current.AddStudent(student);
            Console.WriteLine("===//==================//===");
        }

        static void ListStudents() {
            Console.WriteLine("===== List of Students ======");
                StudentService.Current.PrintStudents();
            Console.WriteLine("=====//==============//======");
        }

        static void AddStudentToCourse() {
            Console.WriteLine("===== Add Student To Course ======");
            Student selectedStudent = StudentService.Current.SelectStudent();
            Course selectedCourse = CourseService.Current.SelectCourse();
            CourseService.Current.AddStudent(selectedStudent, selectedCourse);
            selectedStudent.AddCourse(selectedCourse);
            Console.WriteLine(selectedStudent.Name + " enrolled into " + selectedCourse.Code);
            Console.WriteLine("=====//===================//======");
        }

        static void RemoveStudentFromCourse() {
            Console.WriteLine("=== Removing Student from Course ===");
            Course selectedCourse = CourseService.Current.SelectCourse();
            string searchQuery = selectedCourse.Name;
            List<Course> searchResults = CourseService.Current.Search(searchQuery);

            searchResults[0].PrintCourseDetails();
            Console.WriteLine("Please select student to delete: ");
            int intTemp = Convert.ToInt32(Console.ReadLine());

            List<Student> queryStudent = StudentService.Current.Search(searchResults[0]?.GetStudentName(intTemp-1)??"Error Getting Name");
            Student selectedStudent = queryStudent[0];

            selectedStudent.RemoveCourse(selectedCourse);
            CourseService.Current.RemoveStudent(intTemp, selectedCourse);

            Console.WriteLine("===//==========================//===");
        }

        static void AddAssignmentToCourse() {
            Console.WriteLine("===== Create Assignment for Course ======");
            Console.WriteLine("Assignment Name:");
            string? name = Console.ReadLine();
            Console.WriteLine("Assignment Description:");
            string? description = Console.ReadLine();
            Console.WriteLine("Assignment Due Date:");
            string? dueDate = Console.ReadLine();
            Console.WriteLine("Total Points:");
            double points = Convert.ToDouble(Console.ReadLine());;

            Assignment newAssignment = CourseService.Current.CreateAssignment(name??"EMPTY", description??"EMPTY", points, dueDate??"EMPTY");
            Console.WriteLine("Which Course?");
            Course selectedCourse = CourseService.Current.SelectCourse();
            CourseService.Current.AddAssignment(newAssignment, selectedCourse);

            Console.WriteLine(newAssignment.Name + " added to " + selectedCourse.Code);
            Console.WriteLine("=====//======================//======");
        }

        static void PrintAssignments() {
            Console.WriteLine("===== Print Course Assignments ======");
            Course selectedCourse = CourseService.Current.SelectCourse();
            selectedCourse.printAssignments();
            Console.WriteLine("=====//======================//======");
        }

            static void UpdateCourseInfo() {
            Console.WriteLine("===== Update a Course's Information ======");

            Course selectedCourse = CourseService.Current.SelectCourse();
            Console.WriteLine("New Course Name (press enter to skip):");
            string? name = Console.ReadLine();
            Console.WriteLine("New Course Code (press enter to skip):");
            string? code = Console.ReadLine();
            Console.WriteLine("New Course Description (press enter to skip):");
            string? description = Console.ReadLine();

            if(name != ""){
                selectedCourse.Name = name??"EMPTY";
            }
            if(code != ""){
                selectedCourse.Code = code??"EMPTY";
            }
            if(description != ""){
                selectedCourse.Description = description;
            }

            Console.WriteLine("Updated Course Details:");
            selectedCourse.PrintCourseDetails();
            Console.WriteLine("=====//=========================//======");
        }

        static void UpdateStudentInfo() {
            Console.WriteLine("===== Update a Student's Information ======");

            Student selectedStudent = StudentService.Current.SelectStudent();
            Console.WriteLine("New Student Name (press enter to skip):");
            string? name = Console.ReadLine();
            Console.WriteLine("New Student Class (press enter to skip):");
            string? classI = Console.ReadLine();

            if(name != ""){
                selectedStudent.Name = name??"EMPTY";
            }
            if(classI != ""){
                selectedStudent.Class = classI??"EMPTY";
            }
            Console.WriteLine("Updated Student Details:");
            selectedStudent.PrintStudentDetails();
            Console.WriteLine("=====//=========================//======");
        }

        static void ListStudentCourses() {
            Console.WriteLine("===== List a Student's Courses ======");
            Student selectedStudent = StudentService.Current.SelectStudent();
            selectedStudent.PrintStudentDetails();
            Console.WriteLine("=====//======================//======");
        }

        static void PrintMenu() {
            Console.WriteLine("Make a Menu Selection");
            Console.WriteLine("1. Create a course");
            Console.WriteLine("2. Update a course's info");
            Console.WriteLine("3. List all courses");
            Console.WriteLine("4. Search for a course");
            Console.WriteLine("5. Create and add an assignment to a course");

            Console.WriteLine("6. Create a student");
            Console.WriteLine("7. Update a student's info");
            Console.WriteLine("8. List all students");
            Console.WriteLine("9. Search for a student");
            Console.WriteLine("10. List all enrollments for a student");
            Console.WriteLine("11. Enroll student into a course");
            Console.WriteLine("12. Unenroll a student from a course");

        }
        static void MenuController(int userChoice) {
            if(userChoice < 6) {
                if(userChoice == 1){
                    AddCourse();
                }
                else if(userChoice == 2){
                    UpdateCourseInfo();
                }
                else if(userChoice == 3){
                    PrintCourses();
                }
                else if(userChoice == 4){
                    SearchCourses();
                }
                else if(userChoice == 5){
                    AddAssignmentToCourse();
                }
            }
            else if (userChoice < 13) {
                if(userChoice == 6){
                    CreateStudent();
                }
                else if(userChoice == 7){
                    UpdateStudentInfo();
                }
                else if(userChoice == 8){
                    ListStudents();
                }
                else if(userChoice == 9){
                    SearchStudents();
                }
                else if(userChoice == 10){
                    ListStudentCourses();
                }
                else if(userChoice == 11){
                    AddStudentToCourse();
                }
                else if(userChoice == 12){ 
                    RemoveStudentFromCourse();
                }
            }
            else {
                Console.WriteLine("Menu Selection Not Valid");
            }
        }
    }

}
