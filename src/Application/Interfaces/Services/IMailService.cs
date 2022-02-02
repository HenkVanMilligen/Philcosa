using System.Threading.Tasks;
using Philcosa.Application.Requests.Mail;

namespace Philcosa.Application.Interfaces.Services
{
    public interface IMailService
    {
        Task SendAsync(MailRequest request);
    }
}