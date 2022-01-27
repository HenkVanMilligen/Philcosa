using TestApi2.Application.Responses.Identity;
using TestApi2.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestApi2.Application.Interfaces.Chat;
using TestApi2.Application.Models.Chat;

namespace TestApi2.Application.Interfaces.Services
{
    public interface IChatService
    {
        Task<Result<IEnumerable<ChatUserResponse>>> GetChatUsersAsync(string userId);

        Task<IResult> SaveMessageAsync(ChatHistory<IChatUser> message);

        Task<Result<IEnumerable<ChatHistoryResponse>>> GetChatHistoryAsync(string userId, string contactId);
    }
}