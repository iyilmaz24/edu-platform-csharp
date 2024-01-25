

namespace EduPlatform.Models {
    
    public class Grade {
        Grade(double score, string courseN, string assignmentN, string studentN) {
            Score = score; 
            CourseName = courseN;
            AssignmentName = assignmentN;
            StudentName = studentN;
        }

        private double? _score;
        public double? Score {
            get { return _score; }
            set { _score = value; }
        }

        private string? _courseName;
        public string? CourseName {
            get { return _courseName; }
            set { _courseName = value; }
        }

        private string? _assignmentName;
        public string? AssignmentName {
            get { return _assignmentName; }
            set { _assignmentName = value; }
        }

        private string? _studentName;
        public string? StudentName {
            get { return _studentName; }
            set { _studentName = value; }
        }

    }

}