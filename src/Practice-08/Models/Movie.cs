namespace Practice_08.Models
{
    public class Movie
    {
        public string Name { get; private set; }
        public string Category { get; private set; }
        public int ReleasedYear { get; private set; }
        public bool IsAvailable { get; private set; }
        
        public Movie(string name, int releasedYear, string category)
        {
            Name = name;
            ReleasedYear = releasedYear;
            Category = category;
            IsAvailable = true;
        }

        public void MakeUnavailable()
        {
            IsAvailable = false;
        }
    }
}
