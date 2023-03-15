namespace MovieManager.DTOs
{
	public class MovieDTO
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<GenreDTO> Genres { get; set; }
        public ICollection<UserDTO> Actors { get; set; }
    }
}

