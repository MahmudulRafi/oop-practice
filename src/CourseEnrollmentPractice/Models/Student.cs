using System.Collections.ObjectModel;

namespace CourseEnrollmentPractice.Models
{
    public class Student
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        private readonly List<Enrollment> _enrollments;
        public IReadOnlyCollection<Enrollment> Enrollments => _enrollments.AsReadOnly();

        public Student(string id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
            _enrollments = new List<Enrollment>();
        }

        public Enrollment EnrollCourse(Course course)
        {
            if (course is null)
                throw new ArgumentNullException(nameof(course));

            if (_enrollments.Any(e => e.Course == course && !e.IsCompleted))
                throw new InvalidOperationException("Student is already enrolled in this course");

            var enrollment = new Enrollment(course, this);
            _enrollments.Add(enrollment);

            return enrollment;
        }

        public IEnumerable<Course> GetEnrolledCourses()
        {
            return _enrollments.Select(e => e.Course);
        }

        public IEnumerable<Course> GetActiveCourses()
        {
            return _enrollments.Where(e => !e.IsCompleted).Select(e => e.Course);
        }
    }
}
