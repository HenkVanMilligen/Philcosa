using TestApi2.Application.Models.Chat;
using TestApi2.Application.Responses.Identity;
using TestApi2.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestApi2.Application.Interfaces.Chat;

namespace TestApi2.Client.Infrastructure.Managers.Communication
{
    public interface IChatManager : IManager
    {
        Task<IResult<IEnumerable<ChatUserResponse>>> GetChatUsersAsync();

        Task<IResult> SaveMessageAsync(ChatHistory<IChatUser> chatHistory);

        Task<IResult<IEnumerable<ChatHistoryResponse>>> GetChatHistoryAsync(string cId);
    }
}