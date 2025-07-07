namespace Practice_07.Models
{
    public class Homework
    {
        public List<Submission> Submissions { get; private set; }
        public int AssignmentNo { get; private set; }
        public DateTime DueDate { get; private set; }
        public List<string> Tasks { get; private set; }
        public List<string> ReadingMaterials { get; private set; }

        public Homework()
        {
            Tasks = [];
            ReadingMaterials = [];
            Submissions = [];
        }

        public Homework(int assignmentNo, DateTime dueDate, List<string> tasks, List<string> readingMaterials) : this()
        {
            AssignmentNo = assignmentNo;
            DueDate = dueDate;
            Tasks = tasks;
            ReadingMaterials = readingMaterials;
        }

        public void AddSubmission(Submission submission)
        {
            Submissions.Add(submission);
        }

        public Submission? GetSudentSubmission(Student student)
        {
            return Submissions.Find(st => st.SubmittedBy == student);
        }
    }
}
