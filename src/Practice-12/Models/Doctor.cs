using Practice_12.Enums;

namespace Practice_12.Models
{
    public class Doctor
    {
        private const int MaximumPatientNumber = 20;
        private readonly List<Patient> _patients;
        private readonly List<Appointment> _appointments;

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Specialization { get; private set; }

        public Doctor(string name, string email, string specialization = "General Medicine")
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Specialization = specialization;
            _patients = new List<Patient>();
            _appointments = new List<Appointment>();
        }

        public void AssignPatient(Patient patient)
        {
            if (patient == null) throw new ArgumentNullException(nameof(patient));

            if (_patients.Count >= MaximumPatientNumber)
                throw new InvalidOperationException("Maximum patient limit reached");

            _patients.Add(patient);

            patient.AssignDoctor(this);
        }

        public void RemovePatient(Patient patient)
        {
            if (patient == null) throw new ArgumentNullException(nameof(patient));

            _patients.Remove(patient);
        }

        public List<Patient> GetPatients()
        {
            return _patients.ToList();
        }

        public void ScheduleAppointment(Patient patient, DateTime scheduleDateTime)
        {
            ValidatePatient(patient);

            if (scheduleDateTime <= DateTime.Now)
                throw new ArgumentException("Cannot schedule appointment in the past");

            var appointment = new Appointment(this, patient, scheduleDateTime);

            patient.AddAppointment(appointment);

            _appointments.Add(appointment);
        }

        public Diagnosis DiagnosePatient(Patient patient, string condition, string description)
        {
            ValidatePatient(patient);

            var diagnosis = new Diagnosis(condition, description, this, patient);

            patient.AddDiagnosis(diagnosis);

            return diagnosis;
        }

        public Prescription PrescribeTreatment(Patient patient, Diagnosis diagnosis, List<Treatment> treatments, string notes = "")
        {
            ValidatePatient(patient);

            if (treatments == null || treatments.Count == 0)
                throw new ArgumentException("At least one treatment must be provided");

            var prescription = new Prescription(this, patient, notes);

            foreach (var treatment in treatments)
            {
                prescription.AddTreatment(treatment);
            }

            diagnosis.AddPrescription(prescription);

            return prescription;
        }

        public void DischargePatient(Patient patient)
        {
            ValidatePatient(patient);

            patient.Discharge();
            
            RemovePatient(patient);
        }

        public List<Appointment> GetUpcomingAppointments()
        {
            return _appointments.Where(a => a.IsUpcoming).OrderBy(a => a.ScheduleDateTime).ToList();
        }

        public List<Appointment> GetTodaysAppointments()
        {
            var today = DateTime.Today;
            return _appointments.Where(a => a.ScheduleDateTime.Date == today && a.Status == AppointmentStatus.Scheduled)
                              .OrderBy(a => a.ScheduleDateTime).ToList();
        }

        private void ValidatePatient(Patient patient)
        {
            if (patient == null) throw new ArgumentNullException(nameof(patient));

            if (!_patients.Contains(patient))
                throw new InvalidOperationException("Patient is not assigned to this doctor");
        }
    }
}
