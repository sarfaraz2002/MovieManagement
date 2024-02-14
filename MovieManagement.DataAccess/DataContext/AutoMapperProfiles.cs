using AutoMapper;
using MovieManagement.Domain.Dtos.ReqDtos;
using MovieManagement.Domain.Dtos.ResDtos;
using MovieManagement.Domain.Entities;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Genre, GenreResDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

        CreateMap<Movie, MovieResDto>()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
               .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre))
               .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => Enum.GetName(typeof(Rating), src.Rating)))
               .ForMember(dest => dest.Language, opt => opt.MapFrom(src => Enum.GetName(typeof(Language), src.Language)));

        CreateMap<Actor, ActorResDto>()
            .ForMember(dest => dest.Movies, opt => opt.MapFrom(src => src.Movies))
            .ForMember(dest => dest.Biography, opt => opt.MapFrom(src => src.Biography));

        CreateMap<Biography, BiographyResDto>()
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

        CreateMap<ActorReqDto, Actor>()
            .ConstructUsing(src => new Actor())
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName));
        CreateMap<MovieReqDto, Movie>()
           .ConstructUsing(src => new Movie())
           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
           .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
           .ForMember(dest => dest.ActorId, opt => opt.MapFrom(src => src.ActorId))
           .ForMember(dest => dest.GenreId, opt => opt.MapFrom(src => src.GenreId))
           .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.Language))
           .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rating));
    }
}