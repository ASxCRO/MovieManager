using System;
using MovieManager.DTOs;
using MovieManager.Entities;

namespace MovieManager.Services.Declaration
{
	public interface IUserService : IBaseService<User>
    {
        Task<User> Login(LoginDTO entity);
        Task<User> Register(RegisterDTO Entity);
    }
}

