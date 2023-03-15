using System;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using MovieManager.DTOs;
using MovieManager.Entities;
using MovieManager.Repositories.UnitOfWork;
using MovieManager.Services.Declaration;
using MovieManager.Utilities;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

namespace MovieManager.Services.Implementation
{
	public class UserService : IUserService
	{
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;
        private readonly IJwtService jwtService;

        public UserService(IUnitOfWork unitOfWork,IConfiguration configuration, IMapper mapper, IJwtService jwtService)
        {
            this.unitOfWork = unitOfWork;
            this.configuration = configuration;
            this.mapper = mapper;
            this.jwtService = jwtService;
        }

        public async Task<bool> Delete(int id)
        {
            await unitOfWork.Users.Delete(id);
            await unitOfWork.Commit();

            return true;
        }


        public async Task<IEnumerable<User>> GetAll()
        {
            return await unitOfWork.Users.Get();
        }

        public async Task<User> GetById(int id)
        {
            return await unitOfWork.Users.GetByID(id);
        }


        public async Task<bool> Insert(User entity)
        {
            await unitOfWork.Users.Insert(entity);
            await unitOfWork.Commit();

            return true;
        }

        
        public async Task<User> Login(LoginDTO entity)
        {
            if (string.IsNullOrEmpty(entity.Email) || string.IsNullOrEmpty(entity.Password))
                return null;

            var user = (await unitOfWork.Users.Get(p => p.Email == entity.Email)).FirstOrDefault();

            // Check if user exists
            if (user == null)
                return null;

            // Check if password is correct
            if (!VerifyPasswordHash(entity.Password, user.PasswordHash))
                return null;

            // Authentication successful
            return user;
        }


        private bool VerifyPasswordHash(string password, byte[] passwordHash)
        {
            using (var hmac = new HMACSHA512())
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }
            }

            return true;
        }

        public async Task<User> Register(RegisterDTO Entity)
        {
            if (string.IsNullOrWhiteSpace(Entity.Password))
                throw new ArgumentNullException(nameof(Entity.Password));

            if (string.IsNullOrWhiteSpace(Entity.Email))
                throw new ArgumentNullException(nameof(Entity.Email));

            if ((await unitOfWork.Users.Get()).Any(x => x.Email == Entity.Email))
                throw new ArgumentException($"Email {Entity.Email} is already registered");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(Entity.Password, out passwordHash, out passwordSalt);


            var user = mapper.Map<User>(Entity);
            user.PasswordHash = passwordHash;

            user.Token = jwtService.GenerateToken(user.Id);

            await unitOfWork.Users.Insert(user);
            await unitOfWork.Commit();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> Update(User entity)
        {
            await unitOfWork.Users.Update(entity);
            await unitOfWork.Commit();

            return true;
        }
    }
}

