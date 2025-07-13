namespace CourseEnrollmentPractice.Models
{
    public class EnrollmentCollection
    {
        private readonly List<Enrollment> _enrollments;
        private const double MaximumCreditLimitForStudents = 20.0;
        private const int MaximumStudentsPerCourse = 30;
        public EnrollmentCollection()
        {
            _enrollments = [];
        }

        private double CalculateStudentTotalTakenCredit(Student student) => _enrollments.Where(en => en.TakenBy == student).Sum(a => a.Course.Credits);
        private int CalculateTotalCourseEnrollment(Course course) => _enrollments.Count(a => a.Course == course && !a.IsCompleted);
        public List<Enrollment> GetEnrollments() => _enrollments.ToList();
        public List<Enrollment> GetStudentEnrollments(Student student) => _enrollments.Where(a => a.TakenBy == student).ToList();
        public void AddCourseEnrollment(Enrollment enrollment)
        {
            double totalCreditTaken = CalculateStudentTotalTakenCredit(enrollment.TakenBy);

            if (totalCreditTaken + enrollment.Course.Credits > MaximumCreditLimitForStudents)
                throw new InvalidOperationException("Maximum credit limit reached for student");

            int totalEnrollments = CalculateTotalCourseEnrollment(enrollment.Course);

            if (totalEnrollments + 1 > MaximumStudentsPerCourse)
                throw new InvalidOperationException("Maximum students limit reached for course");

            _enrollments.Add(enrollment);
        }
        public void RemoveCourseEnrollment(Course course, Student student)
        {
            if(course == null) throw new ArgumentNullException(nameof(course));

            if(student == null) throw new ArgumentNullException(nameof(student));

            var enrollment = _enrollments.Find(a => a.TakenBy == student && a.Course ==  course);

            if (enrollment is null) throw new InvalidOperationException("No enrollment found for this student of this course");
            
            _enrollments.Remove(enrollment);
        }
    }
}
