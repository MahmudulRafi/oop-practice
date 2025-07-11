namespace Practice_12.Models
{
    public class Patient
    {
        private readonly List<Appointment> _appointments;
        private readonly List<Diagnosis> _medicalHistory;

        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public Doctor PrimaryDoctor { get; private set; }
        public bool IsActive { get; private set; }

        public Patient(string name, string email, DateTime dateOfBirth)
        {
            Name = name;
            Email = email;
            DateOfBirth = dateOfBirth;
            _appointments = [];
            _medicalHistory = [];
            IsActive = true;
        }

        public void AssignDoctor(Doctor doctor)
        {
            PrimaryDoctor = doctor ?? throw new ArgumentNullException(nameof(doctor));
        }

        public void AddAppointment(Appointment appointment)
        {
            _appointments.Add(appointment ?? throw new ArgumentNullException(nameof(appointment)));
        }

        public void AddDiagnosis(Diagnosis diagnosis)
        {
            _medicalHistory.Add(diagnosis ?? throw new ArgumentNullException(nameof(diagnosis)));
        }

        public List<Treatment> GetActiveTreatments()
        {
            return _medicalHistory.SelectMany(a => a.GetActiveTreatments()).ToList();
        }

        public List<Appointment> GetUpcomingAppointments()
        {
            return _appointments.Where(a => a.IsUpcoming).OrderBy(a => a.ScheduleDateTime).ToList();
        }

        public List<Diagnosis> GetMedicalHistory()
        {
            return _medicalHistory.OrderByDescending(d => d.DiagnosisDate).ToList();
        }

        public void Discharge()
        {
            IsActive = false;
        }
    }
}
