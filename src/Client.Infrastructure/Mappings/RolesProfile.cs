using AutoMapper;
using Philcosa.Application.Requests.Identity;
using Philcosa.Application.Responses.Identity;

namespace Philcosa.Client.Infrastructure.Mappings
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