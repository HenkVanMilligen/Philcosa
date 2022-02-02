using MudBlazor;
using System.Threading.Tasks;
using Philcosa.Shared.Managers;

namespace Philcosa.Client.Infrastructure.Managers.Preferences
{
    public interface IClientPreferenceManager : IPreferenceManager
    {
        Task<MudTheme> GetCurrentThemeAsync();

        Task<bool> ToggleDarkModeAsync();
    }
}