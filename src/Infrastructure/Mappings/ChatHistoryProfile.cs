using AutoMapper;
using TestApi2.Application.Interfaces.Chat;
using TestApi2.Application.Models.Chat;
using TestApi2.Infrastructure.Models.Identity;

namespace TestApi2.Infrastructure.Mappings
{
    public class ChatHistoryProfile : Profile
    {
        public ChatHistoryProfile()
        {
            CreateMap<ChatHistory<IChatUser>, ChatHistory<BlazorHeroUser>>().ReverseMap();
        }
    }
}