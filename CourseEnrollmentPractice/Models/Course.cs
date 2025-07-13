namespace CourseEnrollmentPractice.Models
{
    public class Course
    {
        public string Name { get; private set; }
        public string Code { get; private set; } 
        public double Credits { get; private set; }
        public Course(string name, string code, double credits)
        {
            Name = name;
            Code = code;
            Credits = credits;
        }
    }
}
