using Practice_07.Models;

Teacher teacher = new("Zahirul Alam Taiemoon", "OOP Course");

Student student1 = new(101, "Rafi");

Student student2 = new(102, "Rafat");

var homework = teacher.CreateHomework(7, new DateTime(2025 / 07 / 08, DateTimeKind.Local), ["Task 6, 7, 8"]);

teacher.AssignHomework(student1, homework);

teacher.AssignHomework(student2, homework);

student1.SubmitHomework(homework);

student2.SubmitHomework(homework);

PrintSubmissions();

teacher.GradeSubmission(homework, student1, 75, "Need to be better");

teacher.GradeSubmission(homework, student2, 83, "Very good");

PrintSubmissions();

void PrintSubmissions()
{
    Console.WriteLine("Student submissions");

    foreach (var submission in homework.Submissions)
    {
        string gradeInfo = submission.IsGraded ? $" has grade {submission.Grade}" : " has not been graded yet";

        Console.WriteLine($"Assignment - {submission.Homework.AssignmentNo} Submitted by {submission.SubmittedBy.Name} on {submission.SubmittedOn}{gradeInfo}");
    }
}

