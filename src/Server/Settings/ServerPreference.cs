using Philcosa.Shared.Constants.Localization;
using Philcosa.Shared.Settings;
using System.Linq;

namespace Philcosa.Server.Settings
{
    public record ServerPreference : IPreference
    {
        public string LanguageCode { get; set; } = LocalizationConstants.SupportedLanguages.FirstOrDefault()?.Code ?? "en-US";

        //TODO - add server preferences
    }
}