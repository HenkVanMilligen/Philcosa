using Newtonsoft.Json;
using Philcosa.Application.Interfaces.Serialization.Settings;

namespace Philcosa.Application.Serialization.Settings
{
    public class NewtonsoftJsonSettings : IJsonSerializerSettings
    {
        public JsonSerializerSettings JsonSerializerSettings { get; } = new();
    }
}