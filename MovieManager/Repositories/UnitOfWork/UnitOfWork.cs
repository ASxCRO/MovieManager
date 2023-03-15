using System;
using MovieManager.Entities;

namespace MovieManager.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private MovieContext _dbContext;
        public BaseRepository<Genre> GenreRepo { get; set; }
        public BaseRepository<Movie> MovieRepo { get; set; }
        public BaseRepository<Role> RoleRepo { get; set; }
        public BaseRepository<User> UserRepo { get; set; }


        public UnitOfWork(MovieContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<Genre> Genres
        {
            get
            {
                return GenreRepo ??
                    (GenreRepo = new BaseRepository<Genre>(_dbContext));
            }
        }

        public IRepository<Movie> Movies
        {
            get
            {
                return MovieRepo ??
                    (MovieRepo = new BaseRepository<Movie>(_dbContext));
            }
        }

        public IRepository<Role> Roles
        {
            get
            {
                return RoleRepo ??
                    (RoleRepo = new BaseRepository<Role>(_dbContext));
            }
        }

        public IRepository<User> Users
        {
            get
            {
                return UserRepo ??
                    (UserRepo = new BaseRepository<User>(_dbContext));
            }
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}

