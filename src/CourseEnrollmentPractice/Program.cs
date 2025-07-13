using CourseEnrollmentPractice.Models;

var enrollmentCollection = new EnrollmentCollection();  

var course = new Course("OOP Programming", "CSE-1212", 3.0);

var student = new Student("C101", "Mr. X", "x@gmail.com");

var enrollment = student.EnrollCourse(course);   

enrollmentCollection.AddCourseEnrollment(enrollment);

var studentEnrollments = enrollmentCollection.GetStudentEnrollments(student);

foreach (var studentEnrollment in studentEnrollments)
{
    Console.WriteLine($"StudentID : {studentEnrollment.TakenBy.Id} has taken course '{studentEnrollment.Course.Name}' of {studentEnrollment.Course.Credits} credits");
}

enrollmentCollection.RemoveCourseEnrollment(course, student);   
