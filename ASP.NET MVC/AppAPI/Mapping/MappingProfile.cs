using AppAPI.Core.Models;
using AppAPI.DTOs;
using AutoMapper;

namespace AppAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() { 
            //Domain to DTO
            CreateMap<Movie, MovieDto>();
            CreateMap<Movie, SaveMovieDto>();
            CreateMap<Customer, CustomerDto>();
            CreateMap<Genre, GenreDto>();
            CreateMap<MembershipType, MembershipTypeDto>();

            //DTO to Domain
            CreateMap<MovieDto, Movie>()
                .ForMember(m => m.Id, opt => opt.Ignore());
            CreateMap<SaveMovieDto, Movie>()
                .ForMember(m => m.Id, opt => opt.Ignore());
            CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}
