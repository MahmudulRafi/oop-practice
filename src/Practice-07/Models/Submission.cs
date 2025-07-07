namespace Practice_07.Models
{
    public class Submission
    {
        public Student SubmittedBy { get; private set; }
        public Homework Homework { get; private set; }
        public DateTime SubmittedOn { get; private set; }
        public double Mark { get; private set; }
        public string Feedback { get; private set; } = string.Empty;
        public string Grade => GetStudentGrade(Mark);
        public bool IsGraded => !string.IsNullOrEmpty(Grade);

        public Submission(Student student, Homework homework, DateTime submittedOn)
        {
            SubmittedBy = student;
            Homework = homework;
            SubmittedOn = submittedOn;
        }

        public void AddGrade(double mark, string feedback)
        {
            Mark = mark;
            Feedback = feedback;
        }

        private static string GetStudentGrade(double mark) => mark switch
        {
            >= 80 => "A+",
            >= 70 => "A",
            >= 60 => "A-",
            >= 50 => "B+",
            >= 40 => "B",
            >= 33 => "F",
            _ => ""
        };
    }
}