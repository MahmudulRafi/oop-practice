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
            Course = course ?? throw new ArgumentNullException(nameof(course));
            TakenBy = takenBy ?? throw new ArgumentNullException(nameof(takenBy));
            EnrollmentDate = DateTime.Now;
            IsCompleted = false;

            // Add this enrollment to the course's collection
            course.AddEnrollment(this);
        }

        public void Complete()
        {
            IsCompleted = true;
        }
    }
}
