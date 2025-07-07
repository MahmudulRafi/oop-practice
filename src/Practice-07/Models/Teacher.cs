namespace Practice_07.Models
{
    public class Teacher
    {
        public List<Homework> Homeworks { get; private set; }
        public string Name { get; private set; }
        public string Subject { get; private set; }

        public Teacher(string name, string subject)
        {
            Name = name;
            Subject = subject;
            Homeworks = [];
        }

        public Homework CreateHomework(int assignmentNo, DateTime dueDate, List<string> tasks, List<string> readingMaterials = null!)
        {
            var homework = new Homework(assignmentNo, dueDate, tasks, readingMaterials);

            Homeworks.Add(homework);

            return homework;
        }

        public void AssignHomework(Student student, Homework homework)
        {
            student.AssignHomework(homework);
        }

        public void GradeSubmission(Homework homework, Student student, double mark, string feedback)
        {
            var submission = homework.GetSudentSubmission(student)
                ?? throw new ArgumentNullException(nameof(student), "No submission found");

            submission.AddGrade(mark, feedback);
        }
    }
}
