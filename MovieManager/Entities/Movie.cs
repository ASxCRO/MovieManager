using System;
namespace MovieManager.Entities
{
	public class Movie
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TimeSpan Length { get; set; }
        public DateTime FootageStart { get; set; }
        public DateTime FootageEnd { get; set; }
        public User Director { get; set; }
        public HashSet<MovieActor> MoviesActors { get; set; }
        public HashSet<Genre> Genres { get; set; }
    }
}

