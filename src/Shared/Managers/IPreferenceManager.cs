using TestApi2.Shared.Settings;
using System.Threading.Tasks;
using TestApi2.Shared.Wrapper;

namespace TestApi2.Shared.Managers
{
    public interface IPreferenceManager
    {
        Task SetPreference(IPreference preference);

        Task<IPreference> GetPreference();

        Task<IResult> ChangeLanguageAsync(string languageCode);
    }
}