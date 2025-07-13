namespace CourseEnrollmentPractice.Models
{
    public class Student
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public Student(string id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public Enrollment EnrollCourse(Course course)
        {
            if (course is null)
                throw new ArgumentNullException(nameof(course));

            var enrollment = new Enrollment(course, this);

            return enrollment;
        }
    }
}
