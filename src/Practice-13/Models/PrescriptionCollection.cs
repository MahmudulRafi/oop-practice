namespace Practice_13.Models
{
    public class PrescriptionCollection
    {
        private readonly List<Prescription> _prescriptions;

        public PrescriptionCollection()
        {
            _prescriptions = new List<Prescription>();
        }

        private List<Medication> GetPatientActiveMedication(Patient patient) => _prescriptions.Where(a => a.Patient == patient && a.IsActive).Select(a => a.Medication).ToList();
        private List<string> GetPatientContradictoryMedications(Patient patient) => GetPatientActiveMedication(patient).SelectMany(a => a.ContradictoryMedication).ToList();
        public List<Prescription> GetPatientPrescriptions(Patient patient) => _prescriptions.Where(a => a.Patient == patient).ToList();
        public void AddPrescription(Prescription prescription)
        {
            if (prescription == null)
                throw new ArgumentNullException(nameof(prescription));

            var patientContradictoryMedications = GetPatientContradictoryMedications(prescription.Patient);

            if (patientContradictoryMedications.Contains(prescription.Medication.Type))
                throw new InvalidOperationException("This medication can't provide both");

            _prescriptions.Add(prescription);
        }
    }
}
