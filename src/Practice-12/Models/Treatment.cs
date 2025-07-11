using Practice_12.Enums;

namespace Practice_12.Models
{
    public class Treatment
    {
        public TreatmentType TreatmentType { get; private set; }
        public string Description { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool IsActive => DateTime.Now >= StartDate && DateTime.Now <= EndDate;
        public string Instructions { get; private set; }

        public Treatment(TreatmentType treatmentType, string description, DateTime startDate, DateTime endDate, string instructions = "")
        {
            TreatmentType = treatmentType;
            Description = description ?? throw new ArgumentNullException(nameof(description));
            StartDate = startDate;
            EndDate = endDate;
            Instructions = instructions;

            if (endDate < startDate)
                throw new ArgumentException("End date cannot be before start date");
        }
    }
}
