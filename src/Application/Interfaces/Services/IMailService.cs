using TestApi2.Application.Requests.Mail;
using System.Threading.Tasks;

namespace TestApi2.Application.Interfaces.Services
{
    public interface IMailService
    {
        Task SendAsync(MailRequest request);
    }
}