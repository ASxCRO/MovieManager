using System;
using AutoMapper;
using MovieManager.DTOs;
using MovieManager.Entities;
using System.Numerics;

namespace MovieManager.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDTO>();
            CreateMap<Genre, GenreDTO>();
            CreateMap<GenreCreationDTO, Genre>();
            CreateMap<LoginDTO, User>();
            CreateMap<RegisterDTO, User>();
            CreateMap<Role, RoleDTO>();
            CreateMap<Movie, MovieDTO>()
             .ForMember(dto => dto.Genres, ent => ent.MapFrom(p => p.Genres.OrderByDescending(g => g.Name)))
             .ForMember(dto => dto.Actors, ent => ent.MapFrom(p => p.MoviesActors.Select(ma => ma.Actor)));

        }
    }
}

