using Practice_08.Models;

var streamingPlatform = new StreamingPlatform();

var movie1 = new Movie("ABC", 2020, "Cartoon");

var movie2 = new Movie("DEF", 2021, "Short Film");

var movie3 = new Movie("EFJ", 2025, "Cartoon");

streamingPlatform.AddMovie(movie1);

streamingPlatform.AddMovie(movie2);

streamingPlatform.AddMovie(movie3);

PrintAvailableMovies();

var user = new User("Mr. Bean");

user.AddToWatchList(movie1);

user.AddToWatchList(movie3);

user.RateMovie(movie3, 4.5);

user.RateMovie(movie1, 3.5);

PrintRatedMovies();

void PrintAvailableMovies()
{
    Console.WriteLine("Available Movies");

    foreach (var movie in streamingPlatform.GetAvailableMovies())
    {
        Console.WriteLine($"Name : {movie.Name}, Released in : {movie.ReleasedYear}");
    }
}

void PrintRatedMovies()
{
    Console.WriteLine("Rated Movies");

    foreach (var movieRating in user.MovieRatings)
    {
        Console.WriteLine($"{movieRating.RatedBy.Name} rated {movieRating.Ratings} Movie Name : {movieRating.Movie.Name}");
    }
}