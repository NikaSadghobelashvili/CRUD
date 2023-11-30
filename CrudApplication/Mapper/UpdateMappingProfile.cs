using AutoMapper;
using DTO;

public class  MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserProfileUpdateModel, UserProfile>().ReverseMap();
    }
}