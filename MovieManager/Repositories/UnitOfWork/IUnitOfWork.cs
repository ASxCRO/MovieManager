using System;
using MovieManager.Entities;

namespace MovieManager.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Genre> Genres { get; }
        IRepository<Movie> Movies { get; }
        IRepository<User> Users { get; }
        IRepository<Role> Roles { get; }

        Task Commit();
    }
}

