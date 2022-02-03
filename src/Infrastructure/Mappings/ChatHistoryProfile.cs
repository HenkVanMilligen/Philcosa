using AutoMapper;
using Philcosa.Infrastructure.Models.Identity;
using Philcosa.Application.Interfaces.Chat;
using Philcosa.Application.Models.Chat;

namespace Philcosa.Infrastructure.Mappings
{
    public class ChatHistoryProfile : Profile
    {
        public ChatHistoryProfile()
        {
            CreateMap<ChatHistory<IChatUser>, ChatHistory<PhilcosaUser>>().ReverseMap();
        }
    }
}