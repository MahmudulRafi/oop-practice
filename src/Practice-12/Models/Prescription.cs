namespace Practice_12.Models
{
    public class Prescription
    {
        public Doctor PrescribedBy { get; private set; }
        public Patient Patient { get; private set; }
        public List<Treatment> Treatments { get; private set; }
        public DateTime PrescriptionDate { get; private set; }
        public string Notes { get; private set; }

        public Prescription(Doctor prescribedBy, Patient patient, string notes = "")
        {
            PrescribedBy = prescribedBy ?? throw new ArgumentNullException(nameof(prescribedBy));
            Patient = patient ?? throw new ArgumentNullException(nameof(patient));
            PrescriptionDate = DateTime.Now;
            Notes = notes;
            Treatments = new List<Treatment>();
        }

        public void AddTreatment(Treatment treatment)
        {
            Treatments.Add(treatment ?? throw new ArgumentNullException(nameof(treatment)));
        }

        public List<Treatment> GetActiveTreatments()
        {
            return Treatments.Where(t => t.IsActive).ToList();
        }
    }
}
