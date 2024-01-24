
namespace EduPlatform.Models {
    public class Course {

        public string? Name{get; set; }
        public string? Code{get; set;}
        public string? Description{get; set;}
        public Course() {

        }
        public override string ToString()
        {
            return $"({Code}) {Name} - {Description}";
        }
    }
}