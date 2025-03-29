using AutoMapper;
using eUseControl.Domain.Entities.User;
using eUseControl.Web1.Models;

public class AutoMapperProfile : Profile
{
     public AutoMapperProfile()
     {
          CreateMap<UserLogin, ULoginData>();
          CreateMap<UserRegister, URegisterData>();
          CreateMap<UDbTable, UserMinimal>();
     }
}