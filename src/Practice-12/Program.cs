using Practice_12.Enums;
using Practice_12.Models;

try
{
    var doctor = new Doctor("Dr. X", "x@hospital.com", "Cardiology");

    var patient1 = new Patient("Mr. ABC", "abc@email.com", new DateTime(1990, 5, 15));
    var patient2 = new Patient("Mr. XYZ", "jane@email.com", new DateTime(1985, 8, 22));

    doctor.AssignPatient(patient1);
    doctor.AssignPatient(patient2);

    doctor.ScheduleAppointment(patient1, DateTime.Now.AddDays(1));
    doctor.ScheduleAppointment(patient2, DateTime.Now.AddDays(2));

    var diagnosis1 = doctor.DiagnosePatient(patient1, "Hypertension", "High blood pressure detected");

    var treatments = new List<Treatment>
                {
                    new Treatment(TreatmentType.Medicine, "Blood pressure medication", DateTime.Now, DateTime.Now.AddDays(30), "Take once daily with food"),
                    new Treatment(TreatmentType.Observation, "Monitor blood pressure", DateTime.Now, DateTime.Now.AddDays(30), "Check daily")
                };

    doctor.PrescribeTreatment(patient1, diagnosis1, treatments);

    var upcomingAppointments = patient1.GetUpcomingAppointments();
    var activeTreatments = patient1.GetActiveTreatments();
    var medicalHistory = patient1.GetMedicalHistory();

    Console.WriteLine($"Patient {patient1.Name} has {upcomingAppointments.Count} upcoming appointments");
    Console.WriteLine($"Patient {patient1.Name} has {activeTreatments.Count} active treatments");
    Console.WriteLine($"Patient {patient1.Name} has {medicalHistory.Count} entries in medical history");
}
catch (Exception ex)
{
    Console.WriteLine($"An error occured. Message : {ex.Message}");
}
