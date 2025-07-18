using System.Collections.ObjectModel;

namespace CourseEnrollmentPractice.Models
{
    public class Course
    {
        public string Name { get; private set; }
        public string Code { get; private set; } 
        public double Credits { get; private set; }
        private readonly List<Enrollment> _enrollments;
        public IReadOnlyCollection<Enrollment> Enrollments => _enrollments.AsReadOnly();

        public Course(string name, string code, double credits)
        {
            Name = name;
            Code = code;
            Credits = credits;
            _enrollments = new List<Enrollment>();
        }

        internal void AddEnrollment(Enrollment enrollment)
        {
            if (enrollment is null)
                throw new ArgumentNullException(nameof(enrollment));

            if (enrollment.Course != this)
                throw new InvalidOperationException("Enrollment does not belong to this course");

            _enrollments.Add(enrollment);
        }

        public IEnumerable<Student> GetEnrolledStudents()
        {
            return _enrollments.Select(e => e.TakenBy);
        }
    }
}
