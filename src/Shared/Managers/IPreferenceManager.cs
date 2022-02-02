using System.Threading.Tasks;
using Philcosa.Shared.Wrapper;
using Philcosa.Shared.Settings;

namespace Philcosa.Shared.Managers
{
    public interface IPreferenceManager
    {
        Task SetPreference(IPreference preference);

        Task<IPreference> GetPreference();

        Task<IResult> ChangeLanguageAsync(string languageCode);
    }
}