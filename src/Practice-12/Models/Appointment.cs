using Practice_12.Enums;

namespace Practice_12.Models
{
    public class Appointment
    {
        public Doctor Doctor { get; private set; }
        public Patient Patient { get; private set; }
        public DateTime ScheduleDateTime { get; private set; }
        public AppointmentStatus Status { get; private set; }
        public string Notes { get; private set; }

        public Appointment(Doctor doctor, Patient patient, DateTime scheduleDateTime)
        {
            Doctor = doctor ?? throw new ArgumentNullException(nameof(doctor));
            Patient = patient ?? throw new ArgumentNullException(nameof(patient));
            ScheduleDateTime = scheduleDateTime;
            Status = AppointmentStatus.Scheduled;
            Notes = string.Empty;
        }

        public void MarkCompleted(string notes = "")
        {
            Status = AppointmentStatus.Completed;
            Notes = notes;
        }

        public void Cancel(string reason = "")
        {
            Status = AppointmentStatus.Cancelled;
            Notes = reason;
        }

        public bool IsUpcoming => Status == AppointmentStatus.Scheduled && ScheduleDateTime > DateTime.Now;
    }
}
