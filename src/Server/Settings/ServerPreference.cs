using System.Linq;
using TestApi2.Shared.Constants.Localization;
using TestApi2.Shared.Settings;

namespace TestApi2.Server.Settings
{
    public record ServerPreference : IPreference
    {
        public string LanguageCode { get; set; } = LocalizationConstants.SupportedLanguages.FirstOrDefault()?.Code ?? "en-US";

        //TODO - add server preferences
    }
}