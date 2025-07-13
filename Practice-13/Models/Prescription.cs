namespace Practice_13.Models
{
    public class Prescription
    {
        public Patient Patient { get; private set; }
        public Medication Medication { get; private set; }
        public DateTime DateTime { get; private set; }  
        public bool IsActive {get; private set;}

        public Prescription(Patient patient, Medication medication)
        {
            Patient = patient;
            Medication = medication;
            DateTime = DateTime.Now;
            IsActive = true;
        }
    }
}
