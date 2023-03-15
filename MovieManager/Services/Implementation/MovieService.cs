using System;
using MovieManager.Entities;
using MovieManager.Services.Declaration;

namespace MovieManager.Services.Implementation
{
	public class MovieService : IMovieService
	{
		public MovieService()
		{
		}

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Insert(Movie entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Movie entity)
        {
            throw new NotImplementedException();
        }
    }
}

