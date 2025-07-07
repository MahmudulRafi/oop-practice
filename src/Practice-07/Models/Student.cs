namespace Practice_07.Models
{
    public class Student
    {
        public List<Homework> AssignedHomeworks { get; private set; }
        public List<Submission> Submissions { get; private set; }
        public int Roll { get; private set; }
        public string Name { get; private set; }

        public Student(int roll, string name)
        {
            Roll = roll;
            Name = name;

            AssignedHomeworks = [];
            Submissions = [];
        }

        public void AssignHomework(Homework homeworkAssignment)
        {
            AssignedHomeworks.Add(homeworkAssignment);
        }

        public void SubmitHomework(Homework homework)
        {
            if (homework.DueDate.Date > DateTime.Now.Date)
                throw new InvalidOperationException("Can't submit homework. Due date has passed");

            var submission = new Submission(this, homework, DateTime.Now);

            Submissions.Add(submission);

            homework.AddSubmission(submission);
        }
    }
}
