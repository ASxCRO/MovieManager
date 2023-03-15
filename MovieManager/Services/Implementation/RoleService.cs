using System;
using AutoMapper;
using MovieManager.Entities;
using MovieManager.Repositories.UnitOfWork;
using MovieManager.Services.Declaration;

namespace MovieManager.Services.Implementation
{
	public class RoleService : IRoleService
	{
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;

        public RoleService(IUnitOfWork unitOfWork, IConfiguration configuration, IMapper mapper)
		{
            this.unitOfWork = unitOfWork;
            this.configuration = configuration;
            this.mapper = mapper;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            return await unitOfWork.Roles.Get();

        }

        public Task<Role> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Insert(Role entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Role entity)
        {
            throw new NotImplementedException();
        }
    }
}

