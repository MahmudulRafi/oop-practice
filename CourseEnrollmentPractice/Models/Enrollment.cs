namespace CourseEnrollmentPractice.Models
{
    public class Enrollment
    {
        public Course Course { get; private set; }
        public Student TakenBy { get; private set; }    
        public DateTime EnrollmentDate { get; private set; }
        public bool IsCompleted { get; private set; }

        public Enrollment(Course course, Student takenBy)
        {
            Course = course;
            TakenBy = takenBy;
            EnrollmentDate = DateTime.Now;
            IsCompleted = false;
        }
    }
}
