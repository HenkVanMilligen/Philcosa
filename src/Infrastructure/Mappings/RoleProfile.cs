using AutoMapper;
using TestApi2.Infrastructure.Models.Identity;
using TestApi2.Application.Responses.Identity;

namespace TestApi2.Infrastructure.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleResponse, BlazorHeroRole>().ReverseMap();
        }
    }
}