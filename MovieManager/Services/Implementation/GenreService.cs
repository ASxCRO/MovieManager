using System;
using MovieManager.Entities;
using MovieManager.Services.Declaration;

namespace MovieManager.Services.Implementation
{
	public class GenreService : IGenreService
	{
		public GenreService()
		{
		}

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Genre>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Genre> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Insert(Genre entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Genre entity)
        {
            throw new NotImplementedException();
        }
    }
}

