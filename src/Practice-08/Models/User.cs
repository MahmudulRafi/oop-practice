namespace Practice_08.Models
{
    public class User
    {
        public List<Movie> WatchList { get; private set; }
        public List<Rating> MovieRatings { get; private set; }
        public string Name { get; private set; }

        public User(string name)
        {
            Name = name;
            WatchList = [];
            MovieRatings = [];
        }

        public void AddToWatchList(Movie movie)
        {
            WatchList.Add(movie);
        }

        public void RateMovie(Movie movie, double ratings)
        {
            var rating = new Rating(movie, this, ratings);

            MovieRatings.Add(rating);
        }

    }
}
