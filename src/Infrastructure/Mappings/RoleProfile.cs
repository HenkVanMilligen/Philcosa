using AutoMapper;
using Philcosa.Application.Responses.Identity;
using Philcosa.Infrastructure.Models.Identity;

namespace Philcosa.Infrastructure.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleResponse, BlazorHeroRole>().ReverseMap();
        }
    }
}