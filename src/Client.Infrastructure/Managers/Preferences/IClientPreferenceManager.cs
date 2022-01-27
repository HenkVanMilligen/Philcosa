using TestApi2.Shared.Managers;
using MudBlazor;
using System.Threading.Tasks;

namespace TestApi2.Client.Infrastructure.Managers.Preferences
{
    public interface IClientPreferenceManager : IPreferenceManager
    {
        Task<MudTheme> GetCurrentThemeAsync();

        Task<bool> ToggleDarkModeAsync();
    }
}