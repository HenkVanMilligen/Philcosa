using AutoMapper;
using Philcosa.Application.Responses.Identity;
using Philcosa.Infrastructure.Models.Identity;

namespace Philcosa.Infrastructure.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserResponse, PhilcosaUser>().ReverseMap();
            CreateMap<ChatUserResponse, PhilcosaUser>().ReverseMap()
                .ForMember(dest => dest.EmailAddress, source => source.MapFrom(source => source.Email)); //Specific Mapping
        }
    }
}