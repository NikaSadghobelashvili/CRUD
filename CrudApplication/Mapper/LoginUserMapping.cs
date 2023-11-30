using AutoMapper;
using CrudApplication.Models;
using DTO;

public class LoginUserMapping : Profile
{
    public LoginUserMapping()
    {
        CreateMap<LoginModel, User>().ReverseMap();
    }
}