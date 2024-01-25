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

            Student michael = new Student("Mike", "SENR");
            SaveStudent(michael);
            Student ana = new Student("Ana", "SOPH");
            Student john = new Student("John", "JUNR");
            SaveStudent(ana);
            SaveStudent(john);

            SearchCourses();

            ListStudents();
        }

        static void AddCourse() {
            
            Console.WriteLine("Name:");
            var name = Console.ReadLine();

            Console.WriteLine("Code:");
            var code = Console.ReadLine();

            Console.WriteLine("Description:");
            var description = Console.ReadLine();

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
            Console.WriteLine("Please provide course name or code:");
            string? queryInput = Console.ReadLine();

            Console.WriteLine("===== Search Results ======");
                CourseService.Current.Search(queryInput);
            Console.WriteLine("=====//============//======");
        }   

        static void SaveStudent(Student student) {
            StudentService.Current.AddStudent(student);
        }

        static void ListStudents() {
            Console.WriteLine("===== List of Students ======");
                StudentService.Current.PrintStudents();
            Console.WriteLine("=====//==============//======");
        }





    }



}


