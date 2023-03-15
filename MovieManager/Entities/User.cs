namespace MovieManager.Entities
{
	public class User
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public string? Token { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public HashSet<MovieActor> MoviesActors { get; set; }
    }
}

