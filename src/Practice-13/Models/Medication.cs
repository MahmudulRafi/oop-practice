namespace Practice_13.Models
{
    public class Medication
    {
        public string Name { get; private set; }
        public string Type { get; private set; }    
        public List<string> ContradictoryMedication { get; private set; }

        public Medication(string name, string type)
        {
            Name = name;
            Type = type;
            ContradictoryMedication = [];
        }

        public void AddContradictoryMedication(string contradictoryMedication)
        {
            if (string.IsNullOrEmpty(contradictoryMedication))
                throw new ArgumentNullException(nameof(contradictoryMedication));

            ContradictoryMedication.Add(contradictoryMedication);   
        }
    }
}
