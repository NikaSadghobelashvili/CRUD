using AutoMapper;
using CrudApplication.Models;
using DTO;

public class UserRegistrationMapping : Profile
{
    public UserRegistrationMapping()
    {
        CreateMap<RegisterUserModel, UserProfile>().ReverseMap();
        CreateMap<RegisterUserModel, User>().ReverseMap();
    }
}