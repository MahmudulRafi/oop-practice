namespace Practice_08.Models
{
    public class StreamingPlatform
    {
        public List<Movie> Movies { get; private set; }

        public StreamingPlatform()
        {
            Movies = [];
        }

        public List<Movie> GetAvailableMovies() => Movies.Where(a => a.IsAvailable).ToList();

        public void AddMovie(Movie movie)
        {
            Movies.Add(movie);
        }
    }
}
