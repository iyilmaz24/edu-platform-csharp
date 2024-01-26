using System;
using System.ComponentModel.DataAnnotations;
using System.IO.Compression;
using EduPlatform.Models;
using EduPlatform.Services;

namespace EduPlatform {

    internal class Program 
    {
        static void Main(string [] args) {

            Console.WriteLine("Welcome to C# Edu Platform!");
            
            // AddCourse();
            AddCourse();
            AddCourse();
            PrintCourses();

            CreateStudent();
            CreateStudent();

            AddStudentToCourse();
            // AddStudentToCourse();
            // AddStudentToCourse();

            SearchCourses();

            AddAssignmentToCourse();
            PrintAssignments();
            PrintAssignments();

            // SearchCourses();
            // ListStudents();

            // need to make user select a student and then select a course
                // AddStudentToCourse(ana);

            // RemoveStudentFromCourse();
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
    }


}


