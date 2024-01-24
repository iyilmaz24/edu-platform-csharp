using System;
using EduPlatform.Models;

namespace EduPlatform {

    internal class Program 
    {
        static void Main(string [] args) {

            Console.WriteLine("Hello, World!");
            Console.WriteLine("Running in Main, inside of Program");
            
            Course mainCourse = AddCourse();
            Console.WriteLine(mainCourse.ToString());
        }
        static Course AddCourse() {
            
            Console.WriteLine("Name:");
            var name = Console.ReadLine();

            Console.WriteLine("Code:");
            var code = Console.ReadLine();

            Console.WriteLine("Description:");
            var description = Console.ReadLine();

            Course newCourse;
            newCourse = new Course{Name = name, Code = code, Description = description};
            return newCourse;

            // CourseService.Current.Add(newCourse);
        }
    }



}


