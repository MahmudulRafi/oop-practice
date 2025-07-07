namespace Practice_08.Models
{
    public class Rating
    {
        public Movie Movie { get; private set; }
        public User RatedBy { get; private set; }
        public double Ratings { get; private set; }

        public Rating(Movie movie, User ratedBy, double ratings)
        {
            Movie = movie;
            RatedBy = ratedBy;
            Ratings = ratings;
        }
    }
}
