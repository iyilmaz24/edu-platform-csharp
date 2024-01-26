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
            PrintCourses();

            CreateStudent();
            CreateStudent();

            AddStudentToCourse();
            AddStudentToCourse();
            
            // SearchCourses();
            // ListStudents();

            // need to make user select a student and then select a course
                // AddStudentToCourse(ana);

            RemoveStudentFromCourse();
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
            List<Course> searchResults = CourseService.Current.Search(queryInput);

            Console.WriteLine("===== Search Results ======");
                if(searchResults.Count() == 0){
                    Console.WriteLine("Returned 0 Total Results.");
                }
                else {
                    foreach(var c in searchResults){
                        Console.WriteLine(c.ToString());
                    }
                }
            Console.WriteLine("=====//============//======");
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


                // implement a search feature to find a specific student in Students list from StudentService
                // use the returned queried student model and take it's name

                // remove the student from the selectedCourse roster
                    // query the List of Person models and remove the one with the same name

                // CourseService.Current.RemoveStudent(student, selectedCourse);


                // remove the selectedCourse from the student's roster 
                // student.RemoveCourse(selectedCourse);

            Console.WriteLine("===//==========================//===");
            // DEBUG
            // selectedCourse.PrintCourseDetails();
            // student.PrintStudentDetails(); 
        }


    }


}


