
using ApiUser.Data.Entites;
using ApiUser.Resources.User;
using AutoMapper;
using System;

namespace ApiUser.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterResource, User>()
               .ForMember(d => d.Status, opt => opt
               .MapFrom(src => true))
               .ForMember(d => d.AddedDate, opt => opt
               .MapFrom(src => DateTime.Now))
               .ForMember(d => d.AddedBy, opt => opt
               .MapFrom(src => "System"))
               .ForMember(d => d.Password, opt => opt
               .MapFrom(src => CryptoHelper.Crypto.HashPassword(src.Password)))
               .ForMember(d => d.Token, opt => opt
               .MapFrom(src => CryptoHelper.Crypto.HashPassword(DateTime.Now.ToString())));


            CreateMap<User, UserResource>()
                .ForMember(x => x.RegisterDate, opt => opt
                .MapFrom(src => src.AddedDate.ToString("dd.MMMM.yyyy")));







        }
    }
}
