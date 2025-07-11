namespace Practice_12.Models
{
    public class Diagnosis
    {
        private readonly List<Prescription> _prescriptions;

        public string Condition { get; private set; }
        public string Description { get; private set; }
        public DateTime DiagnosisDate { get; private set; }
        public Doctor DiagnosedBy { get; private set; }
        public Patient Patient { get; private set; }

        public Diagnosis(string condition, string description, Doctor diagnosedBy, Patient patient)
        {
            Condition = condition;
            Description = description;
            DiagnosedBy = diagnosedBy;
            Patient = patient;
            DiagnosisDate = DateTime.Now;
            _prescriptions = [];
        }

        public void AddPrescription(Prescription prescription)
        {
            _prescriptions.Add(prescription ?? throw new ArgumentNullException(nameof(prescription)));
        }

        public List<Treatment> GetActiveTreatments()
        {
            return _prescriptions.SelectMany(p => p.GetActiveTreatments()).ToList();
        }

        public List<Prescription> GetPrescriptions()
        {
            return _prescriptions.OrderByDescending(p => p.PrescriptionDate).ToList();
        }
    }
}
