using System.Collections.Generic;
using System.Threading.Tasks;
using Philcosa.Application.Interfaces.Chat;
using Philcosa.Application.Responses.Identity;
using Philcosa.Application.Models.Chat;
using Philcosa.Shared.Wrapper;

namespace Philcosa.Application.Interfaces.Services
{
    public interface IChatService
    {
        Task<Result<IEnumerable<ChatUserResponse>>> GetChatUsersAsync(string userId);

        Task<IResult> SaveMessageAsync(ChatHistory<IChatUser> message);

        Task<Result<IEnumerable<ChatHistoryResponse>>> GetChatHistoryAsync(string userId, string contactId);
    }
}