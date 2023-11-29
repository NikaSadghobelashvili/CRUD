using AutoMapper;
using CrudApplication.Models;
using DTO;

public class UserProfileMappingProfile : Profile
{
    public UserProfileMappingProfile()
    {
        CreateMap<UserProfileRecord,UserProfile>().ReverseMap();
    }
}