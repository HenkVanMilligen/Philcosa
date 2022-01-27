using AutoMapper;
using TestApi2.Application.Requests.Identity;
using TestApi2.Application.Responses.Identity;

namespace TestApi2.Client.Infrastructure.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<PermissionResponse, PermissionRequest>().ReverseMap();
            CreateMap<RoleClaimResponse, RoleClaimRequest>().ReverseMap();
        }
    }
}